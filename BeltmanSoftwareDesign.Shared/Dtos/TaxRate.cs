namespace BeltmanSoftwareDesign.Shared.Dtos;

public class TaxRate : IEntity
{
    public long Id { get; set; }

    public long? CountryId { get; set; }
    public string? CountryName { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Percentage { get; set; }
}