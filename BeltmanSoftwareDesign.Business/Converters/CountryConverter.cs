namespace BeltmanSoftwareDesign.Data.Converters
{
    public class CountryConverter
    {
        public Shared.Dtos.Country Create(Entities.Country a)
        {
            return new Shared.Dtos.Country()
            {
                Id = a.Id,
                Code = a.Code,
                Name = a.Name
            };
        }
    }
}
