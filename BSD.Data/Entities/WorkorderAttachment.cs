using CodeGenerator.Shared.Attributes;
using Storage.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class WorkorderAttachment : IStorageFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long WorkorderId { get; set; }
    public virtual Workorder? Workorder { get; set; }

    string IStorageFile.Id => Id.ToString();
}
