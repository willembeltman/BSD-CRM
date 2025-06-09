using BSD.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

public class BankStatementInvoice : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? BankStatementId { get; set; }
    public virtual BankStatement? BankStatement { get; set; }

    public long? InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; }
}
