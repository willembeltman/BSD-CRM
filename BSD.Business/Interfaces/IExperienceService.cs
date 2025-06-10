using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IExperienceService
{
    ExperienceCreateResponse Create(ExperienceCreateRequest request);
    ExperienceDeleteResponse Delete(ExperienceDeleteRequest request);
    ExperienceListResponse List(ExperienceListRequest request);
    ExperienceReadResponse Read(ExperienceReadRequest request);
    ExperienceUpdateResponse Update(ExperienceUpdateRequest request);
}