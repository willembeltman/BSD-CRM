using System;


namespace BSD.Shared.Dtos;

public class ClientBearer
{
    public string Id { get; set; } = string.Empty;
    public long? ClientDeviceId { get; set; }
    public long? ClientIpAddressId { get; set; }
    public string? UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}