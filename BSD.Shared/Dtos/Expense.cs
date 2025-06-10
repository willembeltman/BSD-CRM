using System;


namespace BSD.Shared.Dtos;

public class Expense
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public long? ExpenseTypeId { get; set; }
    public long? ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public long? SupplierId { get; set; }
    public long? CustomerId { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public DateTime? DateKapot { get; set; }
    public bool IsPayedInCash { get; set; }
    public double Restwaarde { get; set; }
}