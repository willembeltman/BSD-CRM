using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IExperienceTechnologyService
{
    ExperienceTechnologyCreateResponse Create(ExperienceTechnologyCreateRequest request);
    ExperienceTechnologyDeleteResponse Delete(ExperienceTechnologyDeleteRequest request);
    ExperienceTechnologyListResponse List(ExperienceTechnologyListRequest request);
    ExperienceTechnologyReadResponse Read(ExperienceTechnologyReadRequest request);
    ExperienceTechnologyUpdateResponse Update(ExperienceTechnologyUpdateRequest request);
}