using BSD.Shared;
using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BSD.Data.Entities;

[Hidden]
public class ClientIpAddress : IEntity
{
    [Key]
    public long Id { get; set; }

    [StringLength(128)]
    public string IpAddress { get; set; } = string.Empty;

    public virtual ICollection<ClientBearer> ClientBearers { get; set; } = new List<ClientBearer>();
}
