using System;
using BSD.Shared.Enums;

namespace BSD.Shared.Dtos;

public class ExpenseType
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string? Description { get; set; }
    public bool IsVolledigeKosten { get; set; }
    public bool IsRepresentatieKosten { get; set; }
    public bool IsHalfTellen { get; set; }
    public BedrijfsKostenTypeEnum BedrijfsKostenType { get; set; }
    public AfschrijfKostenTypeEnum AfschrijfKostenType { get; set; }
}