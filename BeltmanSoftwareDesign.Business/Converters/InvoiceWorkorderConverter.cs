namespace BeltmanSoftwareDesign.Data.Converters
{
    public class InvoiceWorkorderConverter
    {
        public Shared.Jsons.InvoiceWorkorder Create(Entities.InvoiceWorkorder a)
        {
            return new Shared.Jsons.InvoiceWorkorder()
            {
                Id = a.Id,
                InvoiceId = a.InvoiceId,
                WorkorderId = a.WorkorderId,
            };
        }
    }
}
