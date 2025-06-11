using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class InvoiceAttachmentServiceHandler
{
    private readonly AuthenticationState State;

    public InvoiceAttachmentServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, InvoiceAttachment entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, InvoiceAttachment entity) => true;
    public bool CanUpdate(ApplicationDbContext db, InvoiceAttachment entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, InvoiceAttachment entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public InvoiceAttachment? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.InvoiceAttachment dto) => null;
    public InvoiceAttachment? FindById(ApplicationDbContext db, long id) => db.InvoiceAttachments.FirstOrDefault(a => a.Id == id);
    public IQueryable<InvoiceAttachment> ListAll(ApplicationDbContext db) => db.InvoiceAttachments;

    public bool AttachToState(ApplicationDbContext db, InvoiceAttachment entity) => true;
    public bool UpdateToState(ApplicationDbContext db, InvoiceAttachment entity, BSD.Shared.Dtos.InvoiceAttachment dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, InvoiceAttachment entity) => true;
}
