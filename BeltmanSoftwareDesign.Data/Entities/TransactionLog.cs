using BeltmanSoftwareDesign.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltmanSoftwareDesign.Data.Entities;

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
