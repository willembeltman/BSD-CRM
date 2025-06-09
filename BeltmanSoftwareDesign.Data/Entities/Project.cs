using BeltmanSoftwareDesign.Data.Attributes;
using BeltmanSoftwareDesign.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace BeltmanSoftwareDesign.Data.Entities;

[DebuggerDisplay("Id = {Id}, Name = {Name}")]
public class Project : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public long? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }

    [Name]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    public bool Publiekelijk { get; set; }

    public virtual ICollection<Workorder>? Workorders { get; set; }
    public virtual ICollection<Invoice>? Invoices { get; set; }
    public virtual ICollection<Expense>? Expenses { get; set; }
    public virtual ICollection<Document>? Documents { get; set; }
}
