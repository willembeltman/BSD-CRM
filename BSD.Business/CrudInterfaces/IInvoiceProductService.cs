using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IInvoiceProductService
{
    InvoiceProductCreateResponse Create(InvoiceProductCreateRequest request);
    InvoiceProductDeleteResponse Delete(InvoiceProductDeleteRequest request);
    InvoiceProductListResponse List(InvoiceProductListRequest request);
    InvoiceProductReadResponse Read(InvoiceProductReadRequest request);
    InvoiceProductUpdateResponse Update(InvoiceProductUpdateRequest request);
}