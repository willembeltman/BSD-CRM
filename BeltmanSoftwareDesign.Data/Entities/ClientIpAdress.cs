using BeltmanSoftwareDesign.Shared;
using System.ComponentModel.DataAnnotations;

namespace BeltmanSoftwareDesign.Data.Entities;

public class ClientIpAddress : IEntity
{
    [Key]
    public long Id { get; set; }

    [StringLength(128)]
    public string IpAddress { get; set; } = string.Empty;

    public virtual ICollection<ClientBearer> ClientBearers { get; set; } = new List<ClientBearer>();
}
