using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IInvoiceTypeService
{
    InvoiceTypeCreateResponse Create(InvoiceTypeCreateRequest request);
    InvoiceTypeDeleteResponse Delete(InvoiceTypeDeleteRequest request);
    InvoiceTypeListResponse List(InvoiceTypeListRequest request);
    InvoiceTypeReadResponse Read(InvoiceTypeReadRequest request);
    InvoiceTypeUpdateResponse Update(InvoiceTypeUpdateRequest request);
}