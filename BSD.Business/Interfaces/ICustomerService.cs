using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Business.Interfaces;

public interface ICustomerService
{
    CustomerCreateResponse Create(CustomerCreateRequest request);
    CustomerDeleteResponse Delete(CustomerDeleteRequest request);
    CustomerListResponse List(CustomerListRequest request);
    CustomerReadResponse Read(CustomerReadRequest request);
    CustomerUpdateResponse Update(CustomerUpdateRequest request);
}
