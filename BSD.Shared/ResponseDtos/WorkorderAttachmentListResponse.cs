using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class WorkorderAttachmentListResponse : BaseResponse
{
    public WorkorderAttachment[] WorkorderAttachments { get; set; } = [];
}