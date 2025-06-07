using StorageServer.Proxy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltmanSoftwareDesign.Data.Entities
{
    public class ExperienceAttachment : IStorageFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long ExperienceId { get; set; }
        //public virtual Experience? Experience { get; set; }

        public bool Spotlight { get; set; }

        [StringLength(255)]
        public string? StorageFileName { get; set; }
        public long? StorageLength { get; set; }
        [StringLength(128)]
		public string? StorageMimeType { get; set; }
        [StringLength(128)]
        public string? StorageMD5 { get; set; }

        [NotMapped]
        public string StorageFolder { get => "ExperienceAttachment"; }
       
    }
}
