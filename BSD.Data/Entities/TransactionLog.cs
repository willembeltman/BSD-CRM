using BSD.Shared;
using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class TransactionLog : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? TransactionId { get; set; }
    public virtual Transaction? Transaction { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ICollection<TransactionLogParameter>? TransactionLogParameters { get; set; }

}
