using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class WorkorderAttachmentCreateResponse : BaseResponse
{
    public WorkorderAttachment? WorkorderAttachment { get; set; }
}