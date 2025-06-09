using BeltmanSoftwareDesign.Shared.RequestJsons;
using BeltmanSoftwareDesign.Shared.ResponseJsons;

namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface ICustomerService
{
    CustomerCreateResponse Create(CustomerCreateRequest request);
    CustomerDeleteResponse Delete(CustomerDeleteRequest request);
    CustomerListResponse List(CustomerListRequest request);
    CustomerReadResponse Read(CustomerReadRequest request);
    CustomerUpdateResponse Update(CustomerUpdateRequest request);
}
