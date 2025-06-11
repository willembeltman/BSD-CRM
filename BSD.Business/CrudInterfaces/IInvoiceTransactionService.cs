using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IInvoiceTransactionService
{
    InvoiceTransactionCreateResponse Create(InvoiceTransactionCreateRequest request);
    InvoiceTransactionDeleteResponse Delete(InvoiceTransactionDeleteRequest request);
    InvoiceTransactionListResponse List(InvoiceTransactionListRequest request);
    InvoiceTransactionReadResponse Read(InvoiceTransactionReadRequest request);
    InvoiceTransactionUpdateResponse Update(InvoiceTransactionUpdateRequest request);
}