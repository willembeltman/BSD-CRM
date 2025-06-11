using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface ITrafficRegistrationService
{
    TrafficRegistrationCreateResponse Create(TrafficRegistrationCreateRequest request);
    TrafficRegistrationDeleteResponse Delete(TrafficRegistrationDeleteRequest request);
    TrafficRegistrationListResponse List(TrafficRegistrationListRequest request);
    TrafficRegistrationReadResponse Read(TrafficRegistrationReadRequest request);
    TrafficRegistrationUpdateResponse Update(TrafficRegistrationUpdateRequest request);
}