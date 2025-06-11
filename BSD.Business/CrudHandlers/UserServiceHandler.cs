using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class UserServiceHandler
{
    private readonly AuthenticationState State;

    public UserServiceHandler(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, User entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, User entity) => true;
    public bool CanUpdate(ApplicationDbContext db, User entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, User entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public User? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.User dto) => null;
    public User? FindById(ApplicationDbContext db, string id) => db.Users.FirstOrDefault(a => a.Id == id);
    public IQueryable<User> ListAll(ApplicationDbContext db) => db.Users;

    public bool AttachToState(ApplicationDbContext db, User entity) => true;
    public bool UpdateToState(ApplicationDbContext db, User entity, BSD.Shared.Dtos.User dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, User entity) => true;
}
