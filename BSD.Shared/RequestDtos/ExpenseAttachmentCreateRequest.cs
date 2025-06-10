using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExpenseAttachmentCreateRequest : BaseRequest
{
    public ExpenseAttachment ExpenseAttachment { get; set; } = new ExpenseAttachment();
}