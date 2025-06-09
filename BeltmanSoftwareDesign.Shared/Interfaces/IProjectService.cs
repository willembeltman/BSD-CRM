using BeltmanSoftwareDesign.Shared.Requests;
using BeltmanSoftwareDesign.Shared.Responses;

namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface IProjectService
{
    ProjectCreateResponse Create(ProjectCreateRequest request);
    ProjectDeleteResponse Delete(ProjectDeleteRequest request);
    ProjectListResponse List(ProjectListRequest request);
    ProjectReadResponse Read(ProjectReadRequest request);
    ProjectUpdateResponse Update(ProjectUpdateRequest request);
}
