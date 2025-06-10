using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IInvoiceService
{
    InvoiceCreateResponse Create(InvoiceCreateRequest request);
    InvoiceDeleteResponse Delete(InvoiceDeleteRequest request);
    InvoiceListResponse List(InvoiceListRequest request);
    InvoiceReadResponse Read(InvoiceReadRequest request);
    InvoiceUpdateResponse Update(InvoiceUpdateRequest request);
}
