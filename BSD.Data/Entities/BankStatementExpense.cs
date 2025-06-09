using BSD.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

public class BankStatementExpense : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? BankStatementId { get; set; }
    public virtual BankStatement? BankStatement { get; set; }

    public long? ExpenseId { get; set; }
    public virtual Expense? Expense { get; set; }
}
