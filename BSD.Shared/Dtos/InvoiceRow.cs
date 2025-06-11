namespace BSD.Shared.Dtos;

public class InvoiceRow
{
    public long Id { get; set; }
    public long? InvoiceId { get; set; }
    public string? InvoiceName { get; set; }
    public long TaxRateId { get; set; }
    public string? TaxRateName { get; set; }
    public double Amount { get; set; }
    public string? Description { get; set; }
    public double PricePerPiece { get; set; }
    public double Price { get; set; }
    public bool IsDiscountRow { get; set; }
}