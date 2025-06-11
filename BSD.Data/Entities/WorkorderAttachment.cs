using BSD.Shared;
using CodeGenerator.Shared.Attributes;
using Storage.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class WorkorderAttachment : IStorageFile, IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long WorkorderId { get; set; }
    public virtual Workorder? Workorder { get; set; }

    [StringLength(128)]
    public string? StorageFileName { get; set; }
    public long? StorageLength { get; set; }
    [StringLength(128)]
    public string? StorageMimeType { get; set; }
    [NotMapped]
    public string StorageFolder { get => "WorkorderAttachment"; }

}
