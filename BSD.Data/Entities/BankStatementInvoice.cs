using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class BankStatementInvoice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? BankStatementId { get; set; }
    public virtual BankStatement? BankStatement { get; set; }

    public long? InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; }
}
