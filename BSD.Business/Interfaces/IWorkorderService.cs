using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IWorkorderService
{
    WorkorderCreateResponse Create(WorkorderCreateRequest request);
    WorkorderDeleteResponse Delete(WorkorderDeleteRequest request);
    WorkorderListResponse List(WorkorderListRequest request);
    WorkorderReadResponse Read(WorkorderReadRequest request);
    WorkorderUpdateResponse Update(WorkorderUpdateRequest request);
}