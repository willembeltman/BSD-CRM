using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class WorkorderAttachmentReadResponse : BaseResponse
{
    public WorkorderAttachment? WorkorderAttachment { get; set; }
}