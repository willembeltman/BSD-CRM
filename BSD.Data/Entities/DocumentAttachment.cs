using CodeGenerator.Shared.Attributes;
using Storage.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class DocumentAttachment : IStorageFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? DocumentId { get; set; }
    public virtual Document? Document { get; set; }

    public string? Description { get; set; }

    string IStorageFile.Id => Id.ToString();
}