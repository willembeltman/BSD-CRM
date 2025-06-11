namespace BSD.Shared.Dtos;

public class ProductPrice
{
    public long Id { get; set; }
    public long? ProductId { get; set; }
    public string? ProductName { get; set; }
    public long? TaxRateId { get; set; }
    public string? TaxRateName { get; set; }
    public double Price { get; set; }
}