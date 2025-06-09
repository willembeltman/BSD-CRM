namespace BeltmanSoftwareDesign.Shared.Jsons;

public class Rate : IEntity
{
    public long Id { get; set; }

    public long? TaxRateId { get; set; }
    public string? TaxRateName { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
}