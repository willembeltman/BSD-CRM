using BSD.Shared.Requests;
using BSD.Shared.Responses;

namespace BSD.Business.Interfaces;

public interface IProjectService
{
    ProjectCreateResponse Create(ProjectCreateRequest request);
    ProjectDeleteResponse Delete(ProjectDeleteRequest request);
    ProjectListResponse List(ProjectListRequest request);
    ProjectReadResponse Read(ProjectReadRequest request);
    ProjectUpdateResponse Update(ProjectUpdateRequest request);
}
