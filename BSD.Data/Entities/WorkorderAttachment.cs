using BSD.Shared;
using Storage.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotMappedAttribute = System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute;

namespace BSD.Data.Entities;

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
