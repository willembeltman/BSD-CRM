using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IInvoiceRowService
{
    InvoiceRowCreateResponse Create(InvoiceRowCreateRequest request);
    InvoiceRowDeleteResponse Delete(InvoiceRowDeleteRequest request);
    InvoiceRowListResponse List(InvoiceRowListRequest request);
    InvoiceRowReadResponse Read(InvoiceRowReadRequest request);
    InvoiceRowUpdateResponse Update(InvoiceRowUpdateRequest request);
}