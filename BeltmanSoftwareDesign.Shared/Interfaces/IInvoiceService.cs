using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface IInvoiceService
{
    InvoiceCreateResponse Create(InvoiceCreateRequest request);
    InvoiceDeleteResponse Delete(InvoiceDeleteRequest request);
    InvoiceListResponse List(InvoiceListRequest request);
    InvoiceReadResponse Read(InvoiceReadRequest request);
    InvoiceUpdateResponse Update(InvoiceUpdateRequest request);
}
