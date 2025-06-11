using BSD.Business.Converters;
using BSD.Business.CrudHandlers;
using BSD.Business.CrudInterfaces;
using BSD.Business.Interfaces;
using BSD.Data;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using CodeGenerator.Shared.Attributes;

namespace BSD.Business.CrudServices;

public class DocumentService(
    ApplicationDbContext db,
    IAuthenticationStateService authenticationService)
    : IDocumentService
{
    [TsServiceMethod("Document", "Create")]
    public DocumentCreateResponse Create(DocumentCreateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentCreateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new DocumentCreateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new DocumentServiceHandler(state);
        var entity = handler.FindByMatch(db, request.Document);
        if (entity != null)
            return new DocumentCreateResponse() { State = state, ErrorAlreadyUsed = true };

        entity = request.Document.ToEntity();
        if (!handler.AttachToState(db, entity))
            return new DocumentCreateResponse() { State = state, ErrorAttachingState = true };

        if (!handler.CanCreate(db, entity))
            return new DocumentCreateResponse() { State = state, ErrorNotAuthorized = true };

        db.Documents.Add(entity);
        db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new DocumentCreateResponse() { State = state, ErrorUpdatingState = true };

        return new DocumentCreateResponse() { State = state, Document = dto, Success = true };
    }

    [TsServiceMethod("Document", "Read")]
    public DocumentReadResponse Read(DocumentReadRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentReadResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new DocumentReadResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new DocumentServiceHandler(state);
        var entity = handler.FindById(db, request.DocumentId);
        if (entity == null)
            return new DocumentReadResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanRead(db, entity))
            return new DocumentReadResponse() { State = state, ErrorNotAuthorized = true };

        var dto = entity.ToDto();
        return new DocumentReadResponse() { State = state, Document = dto, Success = true, };
    }

    [TsServiceMethod("Document", "Update")]
    public DocumentUpdateResponse Update(DocumentUpdateRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentUpdateResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new DocumentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new DocumentServiceHandler(state);
        var entity = handler.FindById(db, request.Document.Id);
        if (entity == null)
            return new DocumentUpdateResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanUpdate(db, entity))
            return new DocumentUpdateResponse() { State = state, ErrorNotAuthorized = true };

        if (request.Document.CopyTo(entity))
            db.SaveChanges();

        var dto = entity.ToDto();
        if (!handler.UpdateToState(db, entity, dto))
            return new DocumentUpdateResponse() { State = state, ErrorUpdatingState = true };

        return new DocumentUpdateResponse() { State = state, Document = dto, Success = true };
    }

    [TsServiceMethod("Document", "Delete")]
    public DocumentDeleteResponse Delete(DocumentDeleteRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentDeleteResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new DocumentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new DocumentServiceHandler(state);
        var entity = handler.FindById(db, request.DocumentId);
        if (entity == null)
            return new DocumentDeleteResponse() { State = state, ErrorItemNotFound = true };

        if (!handler.CanDelete(db, entity))
            return new DocumentDeleteResponse() { State = state, ErrorNotAuthorized = true };

        if (!handler.DeleteFromState(db, entity))
            return new DocumentDeleteResponse() { State = state, ErrorUpdatingState = true };

        db.Documents.Remove(entity);
        db.SaveChanges();

        return new DocumentDeleteResponse() { State = state, Success = true };
    }

    [TsServiceMethod("Document", "List")]
    public DocumentListResponse List(DocumentListRequest request)
    {
        var state = authenticationService.GetState(request);
        if (!state.Success)
            return new DocumentListResponse() { State = state, ErrorGettingState = true };

        if (state.User == null || state.DbUser == null)
            return new DocumentListResponse() { State = state, ErrorNotAuthorized = true };

        var handler = new DocumentServiceHandler(state);
        if (!handler.CanList(db))
            return new DocumentListResponse() { State = state, ErrorNotAuthorized = true };

        var entities = handler.ListAll(db);
        var dtos = entities
            .Select(a => a.ToDto()!)
            .ToArray();

        return new DocumentListResponse()
        {
            Success = true,
            State = state,
            Documents = dtos
        };
    }
}