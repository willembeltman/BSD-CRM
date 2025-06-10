using System;


namespace BSD.Shared.Dtos;

public class ClientDeviceProperty
{
    public long Id { get; set; }
    public long ClientDeviceId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}