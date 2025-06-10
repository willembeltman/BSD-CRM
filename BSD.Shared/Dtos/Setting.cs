using System;


namespace BSD.Shared.Dtos;

public class Setting
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? Name { get; set; }
    public string? ValueString { get; set; }
    public double ValueDouble { get; set; }
}