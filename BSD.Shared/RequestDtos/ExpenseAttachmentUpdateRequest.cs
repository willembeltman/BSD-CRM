using Microsoft.AspNetCore.Http;
using BSD.Shared.Dtos;

namespace BSD.Shared.RequestDtos;

public class ExpenseAttachmentUpdateRequest : BaseRequest
{
    public ExpenseAttachment ExpenseAttachment { get; set; } = new ExpenseAttachment();
    public IFormFile? File { get; set; }
}