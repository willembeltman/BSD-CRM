using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface ITechnologyService
{
    TechnologyCreateResponse Create(TechnologyCreateRequest request);
    TechnologyDeleteResponse Delete(TechnologyDeleteRequest request);
    TechnologyListResponse List(TechnologyListRequest request);
    TechnologyReadResponse Read(TechnologyReadRequest request);
    TechnologyUpdateResponse Update(TechnologyUpdateRequest request);
}