namespace BSD.Data.Converters
{
    public class ProjectConverter
    {
        public Shared.Dtos.Project Create(Entities.Project a)
        {
            return new Shared.Dtos.Project()
            {
                Id = a.Id,
                CustomerId = a.CustomerId,
                CustomerName = a.Customer?.Name,
                Name = a.Name,
                Publiekelijk = a.Publiekelijk,
            };
        }
        public Entities.Project Create(Shared.Dtos.Project a)
        {
            return new Entities.Project()
            {
                Id = a.Id,
                CustomerId = a.CustomerId,
                Name = a.Name,
                Publiekelijk = a.Publiekelijk,
            };
        }

        public bool Copy(Shared.Dtos.Project source, Entities.Project dest)
        {
            var changed = false;
            if (dest.CustomerId != source.CustomerId) { dest.CustomerId = source.CustomerId; changed = true; }
            if (dest.Name != source.Name) { dest.Name = source.Name; changed = true; }
            if (dest.Publiekelijk != source.Publiekelijk) { dest.Publiekelijk = source.Publiekelijk; changed = true; }
            return changed;
        }
    }
}