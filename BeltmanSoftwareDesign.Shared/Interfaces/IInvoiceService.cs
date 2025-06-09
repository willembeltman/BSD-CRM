using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;

namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface IInvoiceService
{
    InvoiceCreateResponse Create(InvoiceCreateRequest request);
    InvoiceDeleteResponse Delete(InvoiceDeleteRequest request);
    InvoiceListResponse List(InvoiceListRequest request);
    InvoiceReadResponse Read(InvoiceReadRequest request);
    InvoiceUpdateResponse Update(InvoiceUpdateRequest request);
}
