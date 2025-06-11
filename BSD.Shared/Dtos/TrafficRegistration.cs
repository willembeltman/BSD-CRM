namespace BSD.Shared.Dtos;

public class TrafficRegistration
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public double KilometerStart { get; set; }
    public double KilometerStop { get; set; }
    public double AmountKm { get; set; }
}