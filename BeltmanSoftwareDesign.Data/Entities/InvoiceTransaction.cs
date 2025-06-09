using BeltmanSoftwareDesign.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltmanSoftwareDesign.Data.Entities;

public class InvoiceTransaction : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; }

    public long TransactionId { get; set; }
    public virtual Transaction? Transaction { get; set; }

}
