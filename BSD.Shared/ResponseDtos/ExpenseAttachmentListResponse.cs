using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class ExpenseAttachmentListResponse : BaseResponse
{
    public ExpenseAttachment[] ExpenseAttachments { get; set; } = [];
}