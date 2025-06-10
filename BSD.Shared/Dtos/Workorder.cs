using System;


namespace BSD.Shared.Dtos;

public class Workorder
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public long? ProjectId { get; set; }
    public long? CustomerId { get; set; }
    public long? RateId { get; set; }
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime Stop { get; set; } = DateTime.Now;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}