using CodeGenerator.Step1.DtosConvertersAndServices.Entities;
using CodeGenerator.Step1.DtosConvertersAndServices.Generators;

namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class CrudHandlerGenerator : BaseGenerator
{
    public CrudHandlerGenerator(
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

        Name = $"{Entity.Name}CrudHandler";
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

    public void GenerateCode()
    {
        var keyType = Entity.Properties.FirstOrDefault(a => a.IsKey)?.TypeSimpleName ?? "long";


        Code = $@"using {AuthenticationState.Namespace};
using {DbContext.Type.Namespace};
using {Entity.Type.Namespace};
using Microsoft.EntityFrameworkCore;

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

    public async Task<{Entity.Name}?> FindByMatch(ApplicationDbContext db, {Dto.FullName} dto) => await Task.Run(() => ({Entity.Name}?)null);
    public async Task<{Entity.Name}?> FindById(ApplicationDbContext db, {keyType} id) => await db.{DbSet.Name}.FirstOrDefaultAsync(a => a.Id == id);
    public IQueryable<{Entity.Name}> ListAll(ApplicationDbContext db) => db.{DbSet.Name};

    public bool AttachToState(ApplicationDbContext db, {Entity.Name} entity) => true;
    public bool UpdateToState(ApplicationDbContext db, {Entity.Name} entity, {Dto.FullName} dto) => true;
    public bool DeleteFromState(ApplicationDbContext db, {Entity.Name} entity) => true;
}}
";
        Save(false);
    }
}