using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IInvoicePriceService
{
    InvoicePriceCreateResponse Create(InvoicePriceCreateRequest request);
    InvoicePriceDeleteResponse Delete(InvoicePriceDeleteRequest request);
    InvoicePriceListResponse List(InvoicePriceListRequest request);
    InvoicePriceReadResponse Read(InvoicePriceReadRequest request);
    InvoicePriceUpdateResponse Update(InvoicePriceUpdateRequest request);
}