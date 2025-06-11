using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IInvoiceEmailService
{
    InvoiceEmailCreateResponse Create(InvoiceEmailCreateRequest request);
    InvoiceEmailDeleteResponse Delete(InvoiceEmailDeleteRequest request);
    InvoiceEmailListResponse List(InvoiceEmailListRequest request);
    InvoiceEmailReadResponse Read(InvoiceEmailReadRequest request);
    InvoiceEmailUpdateResponse Update(InvoiceEmailUpdateRequest request);
}