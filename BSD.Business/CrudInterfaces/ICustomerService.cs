using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface ICustomerService
{
    CustomerCreateResponse Create(CustomerCreateRequest request);
    CustomerDeleteResponse Delete(CustomerDeleteRequest request);
    CustomerListResponse List(CustomerListRequest request);
    CustomerReadResponse Read(CustomerReadRequest request);
    CustomerUpdateResponse Update(CustomerUpdateRequest request);
}