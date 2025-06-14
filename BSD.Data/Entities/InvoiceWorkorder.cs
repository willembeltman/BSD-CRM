﻿using CodeGenerator.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

[Authorize]
public class InvoiceWorkorder
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? InvoiceId { get; set; }
    public virtual Invoice? Invoice { get; set; }

    public long? WorkorderId { get; set; }
    public virtual Workorder? Workorder { get; set; }
}
