namespace BeltmanSoftwareDesign.Shared.Jsons;

public class InvoiceWorkorder : IEntity
{
    public long Id { get; set; }

    public long? InvoiceId { get; set; }
    public long? WorkorderId { get; set; }
}