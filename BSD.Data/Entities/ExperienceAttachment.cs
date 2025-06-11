using Storage.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

public class ExperienceAttachment : IStorageFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long ExperienceId { get; set; }
    //public virtual Experience? Experience { get; set; }

    public bool Spotlight { get; set; }

    string IStorageFile.Id => Id.ToString();
}