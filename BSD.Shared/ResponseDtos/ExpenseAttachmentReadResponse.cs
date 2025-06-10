using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseAttachmentReadResponse : BaseResponse
{
    public ExpenseAttachment? ExpenseAttachment { get; set; }
}