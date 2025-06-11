using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class Setting
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    public string? Name { get; set; }

    public string? ValueString { get; set; }
    public double ValueDouble { get; set; }
}
