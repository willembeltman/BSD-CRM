using BeltmanSoftwareDesign.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltmanSoftwareDesign.Data.Entities;

public class ExperienceTechnology : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? ExperienceId { get; set; }
    public long? TechnologyId { get; set; }
    //public virtual Experience Experience { get; set; }
    //public virtual Technology Technology { get; set; }

}
