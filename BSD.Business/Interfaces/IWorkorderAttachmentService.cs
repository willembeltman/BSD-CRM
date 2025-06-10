using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IWorkorderAttachmentService
{
    WorkorderAttachmentCreateResponse Create(WorkorderAttachmentCreateRequest request);
    WorkorderAttachmentDeleteResponse Delete(WorkorderAttachmentDeleteRequest request);
    WorkorderAttachmentListResponse List(WorkorderAttachmentListRequest request);
    WorkorderAttachmentReadResponse Read(WorkorderAttachmentReadRequest request);
    WorkorderAttachmentUpdateResponse Update(WorkorderAttachmentUpdateRequest request);
}