﻿namespace OnlineSystem.Core.Requests;

public class LoginPayload
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}