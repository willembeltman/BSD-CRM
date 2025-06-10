using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class WorkorderAttachmentUpdateResponse : BaseResponse
{
    public WorkorderAttachment? WorkorderAttachment { get; set; }
}