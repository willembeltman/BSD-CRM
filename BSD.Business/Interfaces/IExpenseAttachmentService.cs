using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IExpenseAttachmentService
{
    ExpenseAttachmentCreateResponse Create(ExpenseAttachmentCreateRequest request);
    ExpenseAttachmentDeleteResponse Delete(ExpenseAttachmentDeleteRequest request);
    ExpenseAttachmentListResponse List(ExpenseAttachmentListRequest request);
    ExpenseAttachmentReadResponse Read(ExpenseAttachmentReadRequest request);
    ExpenseAttachmentUpdateResponse Update(ExpenseAttachmentUpdateRequest request);
}