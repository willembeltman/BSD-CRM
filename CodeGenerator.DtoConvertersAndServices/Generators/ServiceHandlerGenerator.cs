using CodeGenerator.Step1.DtosConvertersAndServices.Entities;
using CodeGenerator.Step1.DtosConvertersAndServices.Generators;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class ServiceHandlerGenerator : BaseGenerator
{
    public ServiceHandlerGenerator(
        DtoConverterGenerator dtoConverter,
        DirectoryInfo directory,
        string @namespace)
    {
        DtoConverter = dtoConverter;
        Directory = directory;
        Namespace = @namespace;

        Dto = DtoConverter.Dto;
        DbSet = Dto.DbSet;
        Entity = DbSet.Entity;

        IAuthenticationStateService = Dto.IAuthenticationStateService;
        AuthenticationState = IAuthenticationStateService.AuthenticationState;
        BaseResponse = AuthenticationState.BaseResponse;
        StateDto = BaseResponse.StateDto;
        BaseRequest = StateDto.BaseRequest;
        DbContext = BaseRequest.DbContext;

        Name = $"{Entity.Name}ServiceHander";
    }

    public DtoConverterGenerator DtoConverter { get; }
    public DtoGenerator Dto { get; }
    public DbSet DbSet { get; }
    public Entity Entity { get; }
    public IAuthenticationStateServiceGenerator IAuthenticationStateService { get; }
    public AuthenticationStateGenerator AuthenticationState { get; }
    public BaseResponseGenerator BaseResponse { get; }
    public StateDtoGenerator StateDto { get; }
    public BaseRequestGenerator BaseRequest { get; }
    public DbContext DbContext { get; }
    public string Namespace { get; private set; }

    public void GenerateCode()
    {
        /// User wijst naar: 
        /// Company, en die wijst weer naar: 
        /// Country.
        
        #region Example code

        //using BSD.Business.Models;
        //using BSD.Data;
        //using BSD.Data.Entities;
        //using Microsoft.EntityFrameworkCore;

        //namespace BSD.Business.ServiceHandlers;

        //public class CompanyServiceHandler
        //{
        //    private readonly AuthenticationState State;

        //    public CompanyServiceHandler(AuthenticationState authenticationState)
        //    {
        //        State = authenticationState;
        //    }

        //    public bool CanCreate(ApplicationDbContext db, Company entity) => true;
        //    public bool CanRead(ApplicationDbContext db, Company entity) => true;
        //    public bool CanUpdate(ApplicationDbContext db, Company entity) =>
        //        State.DbUser != null &&
        //        State.DbUser.CompanyUsers.Any(a => a.Admin && a.CompanyId == entity.Id);
        //    public bool CanDelete(ApplicationDbContext db, Company entity) =>
        //        State.DbUser != null &&
        //        State.DbUser.CompanyUsers.Any(a => (a.Admin || a.Eigenaar) && a.CompanyId == entity.Id);
        //    public bool CanList(ApplicationDbContext db) => true;

        //    public Company? FindByMatch(ApplicationDbContext db, Shared.Dtos.Company dto)
        //    {
        //        var userId = State.User?.Id;
        //        return db.Companies
        //            .Include(a => a.Country)
        //            .FirstOrDefault(a =>
        //                (a.Id == dto.Id || a.Name == dto.Name) &&
        //                a.CompanyUsers.Any(a => a.UserId == userId));
        //    }
        //    public Company? FindById(ApplicationDbContext db, long id)
        //    {
        //        var userId = State.User?.Id;
        //        return db.Companies
        //            .Include(a => a.Country)
        //            .FirstOrDefault(a =>
        //                a.Id == id &&
        //                a.CompanyUsers.Any(a => a.UserId == userId));
        //    }
        //    public IQueryable<Company> ListAll(ApplicationDbContext db)
        //    {
        //        var userId = State.User?.Id;
        //        return db.Companies
        //            .Include(a => a.Country)
        //            .Where(a => a.CompanyUsers.Any(a => a.UserId == userId));
        //    }

        //    public bool AttachToState(ApplicationDbContext db, Company entity)
        //    {
        //        if (State.DbUser == null || State.User == null || entity == null)
        //            return false;

        //        var dbcompanyuser = new CompanyUser()
        //        {
        //            Company = entity,
        //            User = State.DbUser,
        //            Eigenaar = true,
        //            Admin = true,
        //            Actief = true,
        //        };
        //        db.CompanyUsers.Add(dbcompanyuser);

        //        return true;
        //    }
        //    public bool UpdateToState(ApplicationDbContext db, Company entity, Shared.Dtos.Company dto)
        //    {
        //        if (State.DbUser == null || State.User == null)
        //            return false;

        //        State.DbUser.CurrentCompany = entity;
        //        State.DbUser.CurrentCompanyId = entity.Id;
        //        State.User.CurrentCompanyId = entity.Id;
        //        State.DbCurrentCompany = entity;
        //        State.CurrentCompany = dto;
        //        db.SaveChanges();

        //        return true;
        //    }
        //    public bool DeleteFromState(ApplicationDbContext db, Company entity)
        //    {
        //        if (State.DbUser == null || State.User == null)
        //            return false;

        //        var userscurrentcompanywillbedeleted =
        //            State.DbUser.CurrentCompanyId == entity.Id;

        //        if (userscurrentcompanywillbedeleted)
        //        {
        //            State.DbUser.CurrentCompany = null;
        //            State.DbCurrentCompany = null;
        //            State.CurrentCompany = null;
        //            State.User.CurrentCompanyId = null;
        //            State.DbUser.CurrentCompanyId = null;
        //        }

        //        return true;
        //    }
        //}

        #endregion

        var keyType = Entity.Properties.FirstOrDefault(a => a.IsKey)?.TypeSimpleName ?? "long";


        Code = $@"
using {AuthenticationState.Namespace};
using {DbContext.Type.Namespace};
using {Entity.Type.Namespace};

namespace {Namespace};

public class {Name}
{{
    private readonly {AuthenticationState.Name} State;

    public {Name}({AuthenticationState.Name} authenticationState)
    {{
        State = authenticationState;
    }}

    public bool CanCreate(ApplicationDbContext db, {Entity.Name} entity) => State.DbUser != null;
    public bool CanRead(ApplicationDbContext db, {Entity.Name} entity) => true;
    public bool CanUpdate(ApplicationDbContext db, {Entity.Name} entity) => State.DbUser != null;
    public bool CanDelete(ApplicationDbContext db, {Entity.Name} entity) => State.DbUser != null;
    public bool CanList(ApplicationDbContext db) => true;

    public {Entity.Name}? FindByMatch(ApplicationDbContext db, Shared.Dtos.{Entity.Name} dto) => db.{DbSet.Name}.FirstOrDefault(a => a.Id == dto.Id);
    public {Entity.Name}? FindById(ApplicationDbContext db, {keyType} id) => db.{DbSet.Name}.FirstOrDefault(a => a.Id == id);
    public IQueryable<{Entity.Name}> ListAll(ApplicationDbContext db) => db.{DbSet.Name};

    public bool AttachToState(ApplicationDbContext db, {Entity.Name} entity) => true;
    public bool UpdateToState(ApplicationDbContext db, {Entity.Name} entity, Shared.Dtos.{Entity.Name} dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, {Entity.Name} entity) => true;
}}
";
        Save(false);
    }
}