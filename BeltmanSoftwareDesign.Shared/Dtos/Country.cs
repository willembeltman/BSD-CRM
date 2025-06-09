﻿namespace BeltmanSoftwareDesign.Shared.Dtos;

public class Country : IEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

}
