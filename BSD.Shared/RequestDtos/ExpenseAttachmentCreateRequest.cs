using BSD.Shared.Dtos;
using Microsoft.AspNetCore.Http;

namespace BSD.Shared.RequestDtos;

public class ExpenseAttachmentCreateRequest : BaseRequest
{
    public ExpenseAttachment ExpenseAttachment { get; set; } = new ExpenseAttachment();
    public IFormFile? File { get; set; }
}