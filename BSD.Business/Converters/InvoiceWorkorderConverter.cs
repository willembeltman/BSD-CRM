namespace BSD.Data.Converters
{
    public class InvoiceWorkorderConverter
    {
        public Shared.Dtos.InvoiceWorkorder Create(Entities.InvoiceWorkorder a)
        {
            return new Shared.Dtos.InvoiceWorkorder()
            {
                Id = a.Id,
                InvoiceId = a.InvoiceId,
                WorkorderId = a.WorkorderId,
            };
        }
    }
}
