using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IExperienceAttachmentService
{
    ExperienceAttachmentCreateResponse Create(ExperienceAttachmentCreateRequest request);
    ExperienceAttachmentDeleteResponse Delete(ExperienceAttachmentDeleteRequest request);
    ExperienceAttachmentListResponse List(ExperienceAttachmentListRequest request);
    ExperienceAttachmentReadResponse Read(ExperienceAttachmentReadRequest request);
    ExperienceAttachmentUpdateResponse Update(ExperienceAttachmentUpdateRequest request);
}