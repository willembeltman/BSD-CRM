namespace BeltmanSoftwareDesign.Data.Converters
{
    public class InvoiceConverter
    {
        public Entities.Invoice Create(Shared.Jsons.Invoice a)
        {
            return new Entities.Invoice()
            {
                Id = a.Id,

                Description = a.Description,
                CustomerId = a.CustomerId,
                ProjectId = a.ProjectId,

            };
        }

        public Shared.Jsons.Invoice Create(Entities.Invoice a)
        {
            return new Shared.Jsons.Invoice
            {
                Id = a.Id,
                Date = a.Date,
                IsPayed = a.IsPayedInCash,
                IsPayedInCash = a.IsPayedInCash,
                //Quarter = Convert.ToByte(Math.Ceiling(Convert.ToDouble(a.Date.Month) / 3)),
                Description = a.Description,
                CustomerId = a.CustomerId,
                CustomerName = a.Customer?.Name,
                ProjectId = a.ProjectId,
                ProjectName = a.Project?.Name,
            };
        }

        public bool Copy(Shared.Jsons.Invoice source, Entities.Invoice dest)
        {
            var changed = false;
            if (dest.CustomerId != source.CustomerId)
            {
                dest.CustomerId = source.CustomerId;
                changed = true;
            }

            if (dest.Description != source.Description)
            {
                dest.Description = source.Description;
                changed = true;
            }

            if (dest.ProjectId != source.ProjectId)
            {
                dest.ProjectId = source.ProjectId;
                changed = true;
            }

            return changed;
        }
    }
}
