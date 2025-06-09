namespace BeltmanSoftwareDesign.Data.Converters
{
    public class RateConverter
    {
        public Entities.Rate Create(Shared.Dtos.Rate source, Entities.Company currentCompany, ApplicationDbContext db)
        {
            var dest = new Entities.Rate()
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                Company = currentCompany,
                CompanyId = currentCompany.Id,
            };

            Copy(source, dest, currentCompany, db);

            return dest;
        }

        public Shared.Dtos.Rate Create(Entities.Rate a)
        {
            return new Shared.Dtos.Rate
            {
                Id = a.Id,
                TaxRateId = a.TaxRateId,
                TaxRateName = a.TaxRate?.Name,
                Name = a.Name,
                Description = a.Description,
                Price = a.Price,
            };
        }

        public bool Copy(Shared.Dtos.Rate source, Entities.Rate dest, Entities.Company currentCompany, ApplicationDbContext db)
        {
            if (source == null ||
                dest == null ||
                currentCompany == null)
                throw new NotImplementedException();

            if (dest.CompanyId != currentCompany.Id)
                throw new Exception("Cannot change companies");

            var changed = false;

            if (dest.Name != source.Name)
            {
                dest.Description = source.Description;
                changed = true;
            }
            if (dest.Description != source.Description)
            {
                dest.Description = source.Description;
                changed = true;
            }
            if (dest.Price != source.Price)
            {
                dest.Price = source.Price;
                changed = true;
            }

            var taxRateNameLower = (source.TaxRateName ?? "").ToLower();
            var taxRate = db.TaxRates.FirstOrDefault(a =>
                a.CompanyId == currentCompany.Id &&
                (a.Name ?? "").ToLower() == taxRateNameLower);

            if (taxRate == null)
            {
                taxRate = new Data.Entities.TaxRate()
                {
                    Name = source.TaxRateName,
                    CompanyId = currentCompany.Id,
                    Company = currentCompany,
                };
                db.TaxRates.Add(taxRate);
                changed = true;
            }

            if (dest.TaxRateId != taxRate.Id)
            {
                dest.TaxRateId = taxRate.Id;
                changed = true;
            }

            return changed;
        }
    }
}
