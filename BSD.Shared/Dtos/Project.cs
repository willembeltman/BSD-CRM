using System;

namespace BSD.Shared.Dtos;

public class Project
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public long? CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Publiekelijk { get; set; }
}