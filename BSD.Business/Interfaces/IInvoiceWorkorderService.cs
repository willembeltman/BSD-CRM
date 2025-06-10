using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IInvoiceWorkorderService
{
    InvoiceWorkorderCreateResponse Create(InvoiceWorkorderCreateRequest request);
    InvoiceWorkorderDeleteResponse Delete(InvoiceWorkorderDeleteRequest request);
    InvoiceWorkorderListResponse List(InvoiceWorkorderListRequest request);
    InvoiceWorkorderReadResponse Read(InvoiceWorkorderReadRequest request);
    InvoiceWorkorderUpdateResponse Update(InvoiceWorkorderUpdateRequest request);
}