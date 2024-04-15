﻿using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DataBase;
using Server.DataBase.Entities;
using Server.Models;
using Server.Services.Interfaces;

namespace Server.Controllers;

[ApiController]
[Route("api/v1/auth")] // [controller]
public class AuthController : Controller
{
    private readonly DataContext _dbContext = new();
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;
    private readonly IEmailService _emailService;

    public AuthController(ITokenService tokenService, IPasswordService passwordService, IEmailService emailService)
    {
        // _dbContext = dataContext;
        _tokenService = tokenService;
        _passwordService = passwordService;
        _emailService = emailService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var user = await _dbContext
            .Users
            .FirstOrDefaultAsync(x => x.Login == request.Login || x.Email == request.Login);

        if (user is null) return BadRequest("User not found");

        var verifyPassword = _passwordService.VerifyPassword(request.Password, request.Login, user.HashedPassword);
        if (!verifyPassword) return BadRequest("Invalid password");

        var token = _tokenService.CreateAuthToken(user.Login, user.Id.ToString());

        return new LoginResponse(token);
    }

    [HttpPost("registration")]
    public async Task<ActionResult<RegistrationResponse>> Registration([FromBody] RegistrationRequest request)
    {
        if (request.Password != request.ConfirmPassword) return BadRequest("Passwords do not match");

        if (request.Password.Length < 8)
            return BadRequest("Password is too short, need at least 8 characters");

        if (request.Login.Length < 5)
            return BadRequest($"Login is too short, need at least 5 characters");

        var regex = new Regex("^([^ ]+@[^ ]+\\.[a-z]{2,6}|)$");
        if (!regex.IsMatch(request.Email)) return BadRequest("Invalid email");

        if (request.Name.Length == 0 || request.SecondName.Length == 0)
            return BadRequest("Name or second name is empty");

        if (await _dbContext.Users.AnyAsync(x => x.Login == request.Login))
            return BadRequest("Login already exists");

        if (await _dbContext.Users.AnyAsync(x => x.Email == request.Email))
            return BadRequest("Email already exists");

        var user = new UserEntity()
        {
            Login = request.Login,
            HashedPassword = _passwordService.HashPassword(request.Password, request.Login),
            Email = request.Email,
            Name = request.Name,
            SecondName = request.SecondName
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        var id = _dbContext.Users.First(x => x.Login == user.Login).Id;

        await _emailService.SendConfirmationUrl(user.Email,
            _tokenService.CreateEmailConfirmationToken(user.Login, id.ToString()));

        return new RegistrationResponse(_tokenService.CreateAuthToken(user.Login, id.ToString()));
    }

    [HttpPost("password-reset")]
    public async Task<ActionResult> PasswordReset([FromBody] PasswordResetRequest request)
    {
        var regex = new Regex("^([^ ]+@[^ ]+\\.[a-z]{2,6}|)$");
        if (!regex.IsMatch(request.Email)) return BadRequest("Invalid email");

        if (!await _dbContext.Users.AnyAsync(x => x.Email == request.Email))
            return BadRequest("Email not found");

        var user = await _dbContext.Users.FirstAsync(x => x.Email == request.Email);
        await _emailService.SendPasswordResetUrl(request.Email,
            _tokenService.CreatePasswordResetToken(user.Login, user.Id.ToString()));
        return Ok("Email sent");
    }

    [Authorize(Policy = "password_reset")]
    [HttpPut("change-password")]
    public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        if (request.Password != request.ConfirmPassword) return BadRequest("Passwords do not match");

        if (request.Password.Length < 8)
            return BadRequest("Password is too short, need at least 8 characters");

        var userIdRequest = User.FindFirstValue("id");
        if (userIdRequest is null) return BadRequest("Empty id in the JWT token");

        var user = await _dbContext.Users.FirstAsync(x => x.Id == int.Parse(userIdRequest));
        user.HashedPassword = _passwordService.HashPassword(request.Password, user.Login);
        await _dbContext.SaveChangesAsync();

        return Ok("Password changed");
    }
}