using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseAttachmentCreateResponse : BaseResponse
{
    public ExpenseAttachment? ExpenseAttachment { get; set; }
}