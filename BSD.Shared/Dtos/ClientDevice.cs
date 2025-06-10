using System;


namespace BSD.Shared.Dtos;

public class ClientDevice
{
    public long Id { get; set; }
    public string DeviceHash { get; set; } = string.Empty;
}