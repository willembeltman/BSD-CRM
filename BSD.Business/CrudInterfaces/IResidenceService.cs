using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IResidenceService
{
    ResidenceCreateResponse Create(ResidenceCreateRequest request);
    ResidenceDeleteResponse Delete(ResidenceDeleteRequest request);
    ResidenceListResponse List(ResidenceListRequest request);
    ResidenceReadResponse Read(ResidenceReadRequest request);
    ResidenceUpdateResponse Update(ResidenceUpdateRequest request);
}