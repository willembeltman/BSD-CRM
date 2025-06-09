using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;

namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface IRateService
{
    RateCreateResponse Create(RateCreateRequest request);
    RateDeleteResponse Delete(RateDeleteRequest request);
    RateListResponse List(RateListRequest request);
    RateReadResponse Read(RateReadRequest request);
    RateUpdateResponse Update(RateUpdateRequest request);
}