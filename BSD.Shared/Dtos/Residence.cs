using System;

namespace BSD.Shared.Dtos;

public class Residence
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }
    public double WOZWaarde { get; set; }
}