using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IRateService
{
    RateCreateResponse Create(RateCreateRequest request);
    RateDeleteResponse Delete(RateDeleteRequest request);
    RateListResponse List(RateListRequest request);
    RateReadResponse Read(RateReadRequest request);
    RateUpdateResponse Update(RateUpdateRequest request);
}