using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateWorkorderAttachmentResponse : BaseResponse
{
    public WorkorderAttachment? WorkorderAttachment { get; set; }
}