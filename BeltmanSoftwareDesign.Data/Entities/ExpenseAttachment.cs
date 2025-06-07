using StorageServer.Proxy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltmanSoftwareDesign.Data.Entities
{
    public class ExpenseAttachment : IStorageFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long? ExpenseId { get; set; }
        public virtual Expense? Expense { get; set; }

        public string Description { get; set; }
        public string EmailUniqueId { get; set; }


        [StringLength(255)]
        public string? StorageFileName { get; set; }
        public long? StorageLength { get; set; }
        [StringLength(128)]
		public string? StorageMimeType { get; set; }
        [StringLength(128)]
        public string? StorageMD5 { get; set; }
        [NotMapped]
        public string StorageFolder { get => "ExpenseAttachment"; }
    }
}
