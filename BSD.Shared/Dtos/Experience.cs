using System;

namespace BSD.Shared.Dtos;

public class Experience
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public long? ProjectId { get; set; }
    public long? CustomerId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime? Stop { get; set; }
    public int? AmountUur { get; set; }
}