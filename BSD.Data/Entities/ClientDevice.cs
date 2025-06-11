using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BSD.Data.Entities;

[Hidden]
public class ClientDevice
{
    [Key]
    public long Id { get; set; }

    [StringLength(128)]
    public string DeviceHash { get; set; } = string.Empty;

    public virtual ICollection<ClientBearer>? ClientBearers { get; set; } = new List<ClientBearer>();
    public virtual ICollection<ClientDeviceProperty>? ClientDeviceProperties { get; set; } = new List<ClientDeviceProperty>();
}