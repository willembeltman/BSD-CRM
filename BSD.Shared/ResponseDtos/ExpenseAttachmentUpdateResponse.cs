using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseAttachmentUpdateResponse : BaseResponse
{
    public ExpenseAttachment? ExpenseAttachment { get; set; }
}