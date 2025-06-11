﻿using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class Workorder
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long CompanyId { get; set; }
    public virtual Company Company { get; set; } = new Company();
    public long? ProjectId { get; set; }
    public virtual Project? Project { get; set; }
    public long? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
    public long? RateId { get; set; }
    public virtual Rate? Rate { get; set; }

    public DateTime Start { get; set; }
    public DateTime Stop { get; set; }
    [Name]
    [StringLength(255)]
    public string? Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<InvoiceWorkorder>? InvoiceWorkorders { get; set; }
    public virtual ICollection<WorkorderAttachment>? WorkorderAttachments { get; set; }

}
