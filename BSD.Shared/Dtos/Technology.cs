using System;


namespace BSD.Shared.Dtos;

public class Technology
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsProgrammeerTaal { get; set; }
}