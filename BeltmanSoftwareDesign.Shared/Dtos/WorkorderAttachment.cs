namespace BeltmanSoftwareDesign.Shared.Dtos;

public class WorkorderAttachment : IEntity
{
    public long Id { get; set; }

    public long WorkorderId { get; set; }

    public string? FileUrl { get; set; }
}