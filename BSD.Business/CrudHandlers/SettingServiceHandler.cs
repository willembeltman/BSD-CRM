using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.CrudHandlers;

public class SettingServiceHandler
{
    private readonly AuthenticationState State;

    public SettingServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Setting entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Setting entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Setting entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Setting entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Setting? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Setting dto) => null;
    public Setting? FindById(ApplicationDbContext db, long id) => db.Settings.FirstOrDefault(a => a.Id == id);
    public IQueryable<Setting> ListAll(ApplicationDbContext db) => db.Settings;

    public bool AttachToState(ApplicationDbContext db, Setting entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Setting entity, BSD.Shared.Dtos.Setting dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Setting entity) => true;
}
