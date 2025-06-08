using StorageServer.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltmanSoftwareDesign.Data.Entities
{
    public class WorkorderAttachment : IStorageFile
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
}
