﻿using BeltmanSoftwareDesign.Shared;
using System.ComponentModel.DataAnnotations;

namespace BeltmanSoftwareDesign.Data.Entities;

public class ClientDeviceProperty : IEntity
{
    [Key]
    public long Id { get; set; }

    public long ClientDeviceId { get; set; }
    public virtual ClientDevice? ClientDevice { get; set; }

    [StringLength(64)]
    public string Name { get; set; } = string.Empty;

    [StringLength(128)]
    public string Value { get; set; } = string.Empty;
}
