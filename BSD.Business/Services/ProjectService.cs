using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.Services;

public class ProjectService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IProjectService
{
    [TsServiceMethod("Project", "Create")]
    public ProjectCreateResponse Create(ProjectCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProjectCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new ProjectServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Project);
        if (entity != null)
            return new ProjectCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Project.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new ProjectCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new ProjectCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Projects.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ProjectCreateResponse() { State = state, ErrorUpdatingState = true };

        return new ProjectCreateResponse() { State = state, Project = dto, Success = true };
    }

    [TsServiceMethod("Project", "Read")]
    public ProjectReadResponse Read(ProjectReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProjectReadResponse() { State = state, ErrorGettingState = true };

        var handler = new ProjectServiceHandler(state);
        var entity = handler.FindById(db, request.ProjectId);
        if (entity == null)
            return new ProjectReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new ProjectReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new ProjectReadResponse() { State = state, Project = dto, Success = true, };
    }

    [TsServiceMethod("Project", "Update")]
    public ProjectUpdateResponse Update(ProjectUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProjectUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new ProjectServiceHandler(state);
        var entity = handler.FindById(db, request.Project.Id);
        if (entity == null)
            return new ProjectUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new ProjectUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Project.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new ProjectUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new ProjectUpdateResponse() { State = state, Project = dto, Success = true };
    }

    [TsServiceMethod("Project", "Delete")]
    public ProjectDeleteResponse Delete(ProjectDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProjectDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new ProjectServiceHandler(state);
        var entity = handler.FindById(db, request.ProjectId);
        if (entity == null)
            return new ProjectDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new ProjectDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new ProjectDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Projects.Remove(entity);
        db.SaveChanges();

        return new ProjectDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Project", "List")]
    public ProjectListResponse List(ProjectListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new ProjectListResponse() { State = state, ErrorGettingState = true };

        var handler = new ProjectServiceHandler(state);
        if (!handler.CanList(db))
            return new ProjectListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new ProjectListResponse()
        {
            Success = true,
            State = state,
            Projects = dtos
        };
    }
}