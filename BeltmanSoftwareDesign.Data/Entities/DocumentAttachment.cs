using StorageServer.Proxy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltmanSoftwareDesign.Data.Entities
{
    public class DocumentAttachment : IStorageFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? DocumentId { get; set; }
        public virtual Document? Document { get; set; }

        public string? Description { get; set; }
    }
}
