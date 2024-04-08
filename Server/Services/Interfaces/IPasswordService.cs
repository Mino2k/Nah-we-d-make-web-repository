﻿namespace Server.Services.Interfaces;

public interface IPasswordService
{
    public string HashPassword(string password);
    public bool VerifyPassword(string password, string hash);
    public string GeneratePassword();
}