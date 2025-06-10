using BSD.Business.Models;
using BSD.Data;
using BSD.Data.Entities;

namespace BSD.Business.ServiceHandlers;

public class ProjectServiceHander
{
    private readonly AuthenticationState State;

    public ProjectServiceHander(AuthenticationState authenticationState)
    {
        State = authenticationState;
    }

    public bool CanCreate(ApplicationDbContext db, Project entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, Project entity) => true;
    public bool CanUpdate(ApplicationDbContext db, Project entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, Project entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public Project? FindByMatch(ApplicationDbContext db, BSD.Shared.Dtos.Project dto) => db.Projects.FirstOrDefault(a => a.Id == dto.Id);
    public Project? FindById(ApplicationDbContext db, long id) => db.Projects.FirstOrDefault(a => a.Id == id);
    public IQueryable<Project> ListAll(ApplicationDbContext db) => db.Projects;

    public bool AttachToState(ApplicationDbContext db, Project entity) => true;
    public bool UpdateToState(ApplicationDbContext db, Project entity, BSD.Shared.Dtos.Project dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, Project entity) => true;
}
