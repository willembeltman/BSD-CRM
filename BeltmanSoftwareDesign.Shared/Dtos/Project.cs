namespace BeltmanSoftwareDesign.Shared.Dtos;

public class Project : IEntity
{
    public long Id { get; set; }

    public long? CustomerId { get; set; }
    public string? CustomerName { get; set; }

    public string Name { get; set; } = string.Empty;
    public bool Publiekelijk { get; set; }
}