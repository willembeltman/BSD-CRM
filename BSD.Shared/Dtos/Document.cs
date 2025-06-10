using System;

namespace BSD.Shared.Dtos;

public class Document
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public long? DocumentTypeId { get; set; }
    public long? ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public long? SupplierId { get; set; }
    public long? CustomerId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string? Name { get; set; }
}