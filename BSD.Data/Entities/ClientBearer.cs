using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BSD.Data.Entities;

[Hidden]
public class ClientBearer
{
    [Key]
    [StringLength(64)]
    public string Id { get; set; } = string.Empty;

    public long? ClientDeviceId { get; set; }
    public virtual ClientDevice? ClientDevice { get; set; }

    public long? ClientIpAddressId { get; set; }
    public virtual ClientIpAddress? ClientIpAddress { get; set; }

    [StringLength(64)]
    public string? UserId { get; set; } = string.Empty;
    public virtual User? User { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

}
