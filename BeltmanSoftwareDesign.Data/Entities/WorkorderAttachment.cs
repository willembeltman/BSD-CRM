using StorageServer.Proxy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltmanSoftwareDesign.Data.Entities
{
    public class WorkorderAttachment : IStorageFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long WorkorderId { get; set; }
        public virtual Workorder? Workorder { get; set; }

        [StringLength(128)]
        public string? StorageFileName { get; set; }
        public long? StorageLength { get; set; }
        [StringLength(128)]
        public string? StorageMimeType { get; set; }
        [StringLength(128)]
        public string? StorageMD5 { get; set; }
        [NotMapped]
        public string StorageFolder { get => "WorkorderAttachment"; }
        
    }
}
