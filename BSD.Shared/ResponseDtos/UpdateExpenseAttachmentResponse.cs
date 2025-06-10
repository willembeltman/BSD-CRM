using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class UpdateExpenseAttachmentResponse : BaseResponse
{
    public ExpenseAttachment? ExpenseAttachment { get; set; }
}