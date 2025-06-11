using CodeGenerator.Shared.Attributes;
using Storage.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class ExpenseAttachment : IStorageFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? ExpenseId { get; set; }
    public virtual Expense? Expense { get; set; }

    public string? Description { get; set; }
    public string? EmailUniqueId { get; set; }

    string IStorageFile.Id => Id.ToString();
}