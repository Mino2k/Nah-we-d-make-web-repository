﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DataBase;
using Server.Models;
using Server.Services.Interfaces;

namespace Server.Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController : Controller
{
    private readonly DataContext _dbContext;
    private readonly IEmailService _emailService;
    private readonly IPasswordService _passwordService;

    public UserController(DataContext dataContext, IEmailService emailService, IPasswordService passwordService)
    {
        _dbContext = dataContext;
        _emailService = emailService;
        _passwordService = passwordService;
    }

    [Authorize(Policy = "auth")]
    [HttpGet("me")]
    public async Task<ActionResult<GetMyInfoResponse>> GetMyInfo()
    {
        var userIdRequest = User.FindFirstValue("id");
        if (userIdRequest is null) return BadRequest("Empty id in the JWT token");

        var user = await _dbContext.Users.FindAsync(int.Parse(userIdRequest));
        if (user is null) return BadRequest("User not found");

        var response = new GetMyInfoResponse(
            user.Login,
            user.Email,
            user.Name,
            user.SecondName,
            user.DateRegistration.ToString("dd.MM.yyyy"),
            user.BirthDate == DateTime.MinValue ? null : user.BirthDate.ToString("dd.MM.yyyy"),
            user.Description,
            user.TelegramLink,
            user.VkLink,
            user.ProfilePhoto
        );
        return response;
    }

    [AllowAnonymous]
    [HttpGet("{nickName}")]
    public async Task<ActionResult<GetMyInfoResponse>> GetUserInfo(string nickName)
    {
        var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
        var user = await _dbContext.Users.FindAsync(userId);
        if (user is null) return BadRequest("User not found");

        var response = new GetMyInfoResponse(
            user.Login,
            user.Email,
            user.Name,
            user.SecondName,
            user.DateRegistration.ToString("dd.MM.yyyy"),
            user.BirthDate == DateTime.MinValue ? null : user.BirthDate.ToString("dd.MM.yyyy"),
            user.Description,
            user.TelegramLink,
            user.VkLink,
            user.ProfilePhoto
        );
        return response;
    }

    [Authorize(Policy = "auth")]
    [HttpPut("{nickName}")]
    public async Task<ActionResult> UpdateUserInfo([FromBody] UpdateUserInfoRequest request, string nickName)
    {
        var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
        var user = await _dbContext.Users.FindAsync(userId);
        if (user is null) return BadRequest("User not found");

        if (user.Login != nickName) return BadRequest("Access denied");

        if (request.Login.Length < 5) return BadRequest($"Login is too short, need at least 5 characters");
        if (!_emailService.ValidateEmail(request.Email)) return BadRequest("Invalid email");
        if (request.NewPassword.Length < 8) return BadRequest("Password is too short, need at least 8 characters");
        if (await _dbContext.Users.AnyAsync(x => x.Login == request.Login)) return BadRequest("Login already exists");
        if (await _dbContext.Users.AnyAsync(x => x.Email == request.Email && x.Id != userId))
            return BadRequest("Email already exists");

        user.ProfilePhoto = request.ProfilePhoto;
        user.Name = request.Name;
        user.SecondName = request.SecondName;
        user.Login = request.Login;
        user.Email = request.Email;
        user.HashedPassword = _passwordService.HashPassword(request.NewPassword, user.Login);

        //TODO: Сделать смену почты через подтверждение
        await _dbContext.SaveChangesAsync();
        return Ok("User info updated");
    }

    [Authorize(Policy = "auth")]
    [HttpDelete("{nickName}")]
    public async Task<ActionResult> DeleteUser(string nickName)
    {
        var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
        var user = await _dbContext.Users
            .Include(x => x.Files)
            .FirstOrDefaultAsync(x => x.Id == userId);

        if (user is null) return BadRequest("User not found");

        if (user.Login != nickName) return BadRequest("Access denied");

        var files = user.Files;
        foreach (var file in files)
        {
            if (!System.IO.File.Exists(file.Path)) continue;
            System.IO.File.Delete(file.Path);
        }

        if (System.IO.File.Exists(user.ProfilePhoto)) System.IO.File.Delete(user.ProfilePhoto);

        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();

        return Ok("User deleted");
    }
}