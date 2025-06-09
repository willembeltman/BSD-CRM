using BSD.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

public class TransactionLogParameter : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long TransactionLogId { get; set; }
    public virtual TransactionLog? TransactionLog { get; set; }

    [StringLength(255)]
    public string? Name { get; set; }

    public string? Value { get; set; }
}
