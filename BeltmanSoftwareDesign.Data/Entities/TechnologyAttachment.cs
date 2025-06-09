using BeltmanSoftwareDesign.Shared;
using StorageServer.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotMappedAttribute = System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute;

namespace BeltmanSoftwareDesign.Data.Entities;

public class TechnologyAttachment : IStorageFile, IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long TechnologyId { get; set; }
    //public virtual Technology Technology { get; set; }


    [StringLength(255)]
    public string? StorageFileName { get; set; }
    public long? StorageLength { get; set; }
    [StringLength(128)]
    public string? StorageMimeType { get; set; }

    [NotMapped]
    public string StorageFolder { get => "TechnologyAttachment"; }
}
