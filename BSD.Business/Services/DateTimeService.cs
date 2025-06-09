using BSD.Business.Interfaces;

namespace BSD.Business.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}
