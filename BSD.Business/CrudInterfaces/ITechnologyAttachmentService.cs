using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface ITechnologyAttachmentService
{
    TechnologyAttachmentCreateResponse Create(TechnologyAttachmentCreateRequest request);
    TechnologyAttachmentDeleteResponse Delete(TechnologyAttachmentDeleteRequest request);
    TechnologyAttachmentListResponse List(TechnologyAttachmentListRequest request);
    TechnologyAttachmentReadResponse Read(TechnologyAttachmentReadRequest request);
    TechnologyAttachmentUpdateResponse Update(TechnologyAttachmentUpdateRequest request);
}