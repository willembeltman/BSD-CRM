using BSD.Business.Interfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExpenseAttachmentController(IExpenseAttachmentService expenseattachment) : ControllerBase
{
    [HttpPost]
    public ExpenseAttachmentCreateResponse Create(ExpenseAttachmentCreateRequest request)
        => expenseattachment.Create(request);

    [HttpPost]
    public ExpenseAttachmentReadResponse Read(ExpenseAttachmentReadRequest request)
        => expenseattachment.Read(request);

    [HttpPost]
    public ExpenseAttachmentUpdateResponse Update(ExpenseAttachmentUpdateRequest request)
        => expenseattachment.Update(request);

    [HttpPost]
    public ExpenseAttachmentDeleteResponse Delete(ExpenseAttachmentDeleteRequest request)
        => expenseattachment.Delete(request);

    [HttpPost]
    public ExpenseAttachmentListResponse List(ExpenseAttachmentListRequest request)
        => expenseattachment.List(request);
}
