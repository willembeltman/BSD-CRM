using Storage.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

public class TechnologyAttachment : IStorageFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long TechnologyId { get; set; }
    //public virtual Technology Technology { get; set; }

    string IStorageFile.Id => Id.ToString();
}