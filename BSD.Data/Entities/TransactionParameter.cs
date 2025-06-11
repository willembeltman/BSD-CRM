using BSD.Shared;
using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class TransactionParameter : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long TransactionId { get; set; }
    public virtual Transaction? Transaction { get; set; }

    [StringLength(255)]
    public string? Name { get; set; }

    public string? Value { get; set; }
}
