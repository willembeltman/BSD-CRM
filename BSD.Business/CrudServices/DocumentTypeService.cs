using BSD.Business.Converters;
using BSD.Business.ServiceHandlers;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class DocumentTypeService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IDocumentTypeService
{
    [TsServiceMethod("DocumentType", "Create")]
    public DocumentTypeCreateResponse Create(DocumentTypeCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentTypeCreateResponse() { State = state, ErrorGettingState = true };

        var handler = new DocumentTypeServiceHandler(state);
        var entity = handler.FindByMatch(db, request.DocumentType);
        if (entity != null)
            return new DocumentTypeCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.DocumentType.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new DocumentTypeCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new DocumentTypeCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.DocumentTypes.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new DocumentTypeCreateResponse() { State = state, ErrorUpdatingState = true };

        return new DocumentTypeCreateResponse() { State = state, DocumentType = dto, Success = true };
    }

    [TsServiceMethod("DocumentType", "Read")]
    public DocumentTypeReadResponse Read(DocumentTypeReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentTypeReadResponse() { State = state, ErrorGettingState = true };

        var handler = new DocumentTypeServiceHandler(state);
        var entity = handler.FindById(db, request.DocumentTypeId);
        if (entity == null)
            return new DocumentTypeReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new DocumentTypeReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new DocumentTypeReadResponse() { State = state, DocumentType = dto, Success = true, };
    }

    [TsServiceMethod("DocumentType", "Update")]
    public DocumentTypeUpdateResponse Update(DocumentTypeUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentTypeUpdateResponse() { State = state, ErrorGettingState = true };

        var handler = new DocumentTypeServiceHandler(state);
        var entity = handler.FindById(db, request.DocumentType.Id);
        if (entity == null)
            return new DocumentTypeUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new DocumentTypeUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.DocumentType.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new DocumentTypeUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new DocumentTypeUpdateResponse() { State = state, DocumentType = dto, Success = true };
    }

    [TsServiceMethod("DocumentType", "Delete")]
    public DocumentTypeDeleteResponse Delete(DocumentTypeDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentTypeDeleteResponse() { State = state, ErrorGettingState = true };

        var handler = new DocumentTypeServiceHandler(state);
        var entity = handler.FindById(db, request.DocumentTypeId);
        if (entity == null)
            return new DocumentTypeDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new DocumentTypeDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new DocumentTypeDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.DocumentTypes.Remove(entity);
        db.SaveChanges();

        return new DocumentTypeDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("DocumentType", "List")]
    public DocumentTypeListResponse List(DocumentTypeListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentTypeListResponse() { State = state, ErrorGettingState = true };

        var handler = new DocumentTypeServiceHandler(state);
        if (!handler.CanList(db))
            return new DocumentTypeListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new DocumentTypeListResponse()
        {
            Success = true,
            State = state,
            DocumentTypes = dtos
        };
    }
}