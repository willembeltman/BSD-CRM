using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface ISupplierService
{
    SupplierCreateResponse Create(SupplierCreateRequest request);
    SupplierDeleteResponse Delete(SupplierDeleteRequest request);
    SupplierListResponse List(SupplierListRequest request);
    SupplierReadResponse Read(SupplierReadRequest request);
    SupplierUpdateResponse Update(SupplierUpdateRequest request);
}