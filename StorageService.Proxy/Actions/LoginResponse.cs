﻿namespace StorageServer.Proxy.Actions;

public class LoginResponse
{
    public bool Success { get; set; }
    public string? Token { get; set; }
}
