﻿namespace Storage.Shared.Requests;

public class DeleteRequest : Request
{
    public bool ThrowIfNotFound { get; set; } = true;
}
