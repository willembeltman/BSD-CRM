namespace BSD.Shared.Dtos;

public class Product
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public long? SupplierId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}