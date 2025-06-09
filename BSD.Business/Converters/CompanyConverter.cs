﻿namespace BSD.Data.Converters
{
    public class CompanyConverter
    {
        public Shared.Dtos.Company Create(Entities.Company a)
        {
            return new Shared.Dtos.Company
            {
                Id = a.Id,
                Name = a.Name,

                Address = a.Address,
                BtwNumber = a.BtwNumber,
                CountryId = a.CountryId,
                CountryName = a.Country?.Name,
                //DateDelete = a.DateDelete,
                //DateInsert = a.DateInsert,
                //DateUpdate = a.DateUpdate,
                Email = a.Email,
                Iban = a.Iban,
                KvkNumber = a.KvkNumber,
                Place = a.Place,
                Postalcode = a.Postalcode,
                PhoneNumber = a.PhoneNumber,
                Website = a.Website,
            };
        }
        public Entities.Company Create(Shared.Dtos.Company a)
        {
            return new Entities.Company
            {
                Id = a.Id,
                Name = a.Name,
                Address = a.Address,
                BtwNumber = a.BtwNumber,
                CountryId = a.CountryId,
                //DateDelete = a.DateDelete,
                //DateInsert = a.DateInsert,
                //DateUpdate = a.DateUpdate,
                Email = a.Email,
                Iban = a.Iban,
                KvkNumber = a.KvkNumber,
                Place = a.Place,
                Postalcode = a.Postalcode,
                PhoneNumber = a.PhoneNumber,
                Website = a.Website,
            };
        }

        public bool Copy(Shared.Dtos.Company source, Entities.Company dest)
        {
            var dirty = false;
            if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
            if (dest.Name != source.Name) { dest.Name = source.Name; dirty = true; }
            if (dest.Address != source.Address) { dest.Address = source.Address; dirty = true; }
            if (dest.BtwNumber != source.BtwNumber) { dest.BtwNumber = source.BtwNumber; dirty = true; }
            if (dest.CountryId != source.CountryId) { dest.CountryId = source.CountryId; dirty = true; }
            //if (dest.DateDelete != source.DateDelete) { dest.DateDelete = source.DateDelete; dirty = true; }
            //if (dest.DateInsert != source.DateInsert) { dest.DateInsert = source.DateInsert; dirty = true; }
            //if (dest.DateUpdate != source.DateUpdate) { dest.DateUpdate = source.DateUpdate; dirty = true; }
            if (dest.Email != source.Email) { dest.Email = source.Email; dirty = true; }
            if (dest.Iban != source.Iban) { dest.Iban = source.Iban; dirty = true; }
            if (dest.KvkNumber != source.KvkNumber) { dest.KvkNumber = source.KvkNumber; dirty = true; }
            if (dest.Place != source.Place) { dest.Place = source.Place; dirty = true; }
            if (dest.Postalcode != source.Postalcode) { dest.Postalcode = source.Postalcode; dirty = true; }
            if (dest.PhoneNumber != source.PhoneNumber) { dest.PhoneNumber = source.PhoneNumber; dirty = true; }
            if (dest.Website != source.Website) { dest.Website = source.Website; dirty = true; }
            return dirty;
        }
    }
}
