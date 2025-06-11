
using BSD.Data;

var config1 = new CodeGenerator.Step1.DtosConvertersAndServices.GeneratorConfig(
    dbContextType: typeof(ApplicationDbContext),
    dtoDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Shared\\Dtos"),
    dtoNamespace: "BSD.Shared.Dtos",
    requestDtoDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Shared\\RequestDtos"),
    requestDtoNamespace: "BSD.Shared.RequestDtos",
    responseDtoDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Shared\\ResponseDtos"),
    responseDtoNamespace: "BSD.Shared.ResponseDtos",
    convertersDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\Converters"),
    convertersNamespace: "BSD.Business.Converters",
    crudHandlersDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\CrudHandlers"),
    crudHandlersNamespace: "BSD.Business.CrudHandlers",
    interfacesDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\Interfaces"),
    interfacesNamespace: "BSD.Business.Interfaces",
    crudServicesDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\CrudServices"),
    crudServicesNamespace: "BSD.Business.CrudServices",
    modelsDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\Models"),
    modelsNamespace: "BSD.Business.Models",
    crudInterfacesDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\CrudInterfaces"),
    crudInterfacesNamespace: "BSD.Business.CrudInterfaces");

//config1 = new CodeGenerator.Step1.DtosConvertersAndServices.GeneratorConfig(
//    dbContextType: typeof(ApplicationDbContext),
//    dtoDirectory: new DirectoryInfo("..\\..\\..\\..\\TestProject\\Dtos"),
//    dtoNamespace: "TestProject.Dtos",
//    requestDtoDirectory: new DirectoryInfo("..\\..\\..\\..\\TestProject\\RequestDtos"),
//    requestDtoNamespace: "TestProject.RequestDtos",
//    responseDtoDirectory: new DirectoryInfo("..\\..\\..\\..\\TestProject\\ResponseDtos"),
//    responseDtoNamespace: "TestProject.ResponseDtos",
//    convertersDirectory: new DirectoryInfo("..\\..\\..\\..\\TestProject\\Converters"),
//    convertersNamespace: "TestProject.Converters",
//    serviceHandlersDirectory: new DirectoryInfo("..\\..\\..\\..\\TestProject\\ServiceHandlers"),
//    serviceHandlersNamespace: "TestProject.ServiceHandlers",
//    interfacesDirectory: new DirectoryInfo("..\\..\\..\\..\\TestProject\\Interfaces"),
//    interfacesNamespace: "TestProject.Interfaces",
//    servicesDirectory: new DirectoryInfo("..\\..\\..\\..\\TestProject\\Services"),
//    servicesNamespace: "TestProject.Services",
//    modelsDirectory: new DirectoryInfo("..\\..\\..\\..\\TestProject\\Models"),
//    modelsNamespace: "TestProject.Models");
var generator1 = new CodeGenerator.Step1.DtosConvertersAndServices.Generator(config1);
generator1.Run();


var config2 = new CodeGenerator.Step2.ApisAndProxies.GeneratorConfig(
    AngularAppDirectory: @"..\..\..\..\BSD.Angular\src\app",
    AngularApiServicesDirectory: @"..\..\..\..\BSD.Angular\src\app\apiservices",
    AngularApiServicesTsNamespace: "apiservices",
    DotNetControllersDirectory: @"..\..\..\..\BSD.Api\Controllers",
    DotNetControllersNamespace: "BSD.Api.Controllers",
    DotNetAddBusinessServicesFileName: @"..\..\..\..\BSD.Business\AddBusinessServicesExtention.cs",
    DotNetAddBusinessServicesNamespace: "BSD.Business",
    DotNetProxiesDirectory: @"..\..\..\..\BSD.Proxy",
    DotNetProxiesNamespace: "BSD.Proxy",
    ModelNamespaces:
    [(
        Assembly: typeof(BSD.Shared.Dtos.Company).Assembly,
        CsNamespace: "BSD.Shared.Dtos",
        TsNamespace: "interfaces"
    ),
    (
        Assembly: typeof(BSD.Shared.RequestDtos.LoginRequest).Assembly,
        CsNamespace: "BSD.Shared.RequestDtos",
        TsNamespace: "interfaces/request"
    ),
    (
        Assembly: typeof(BSD.Shared.ResponseDtos.LoginResponse).Assembly,
        CsNamespace: "BSD.Shared.ResponseDtos",
        TsNamespace: "interfaces/response"
    )],
    ServiceNamespaces:
    [(
        Assembly: typeof(BSD.Business.Services.AuthenticationService).Assembly,
        CsNamespace: "BSD.Business.CrudServices"
    ),
    (
        Assembly: typeof(BSD.Business.Services.AuthenticationService).Assembly,
        CsNamespace: "BSD.Business.Services"
    )]);


//config2 = new CodeGenerator.Step2.ApisAndProxies.GeneratorConfig(
//    AngularAppDirectory: @"..\..\..\..\BSD.Angular\src\app",
//    AngularApiServicesDirectory: @"..\..\..\..\BSD.Angular\src\app\apiservices",
//    AngularApiServicesTsNamespace: "apiservices",
//    DotNetControllersDirectory: @"..\..\..\..\TestProject\Controllers",
//    DotNetControllersNamespace: "TestProject.Controllers",
//    DotNetProxiesDirectory: @"..\..\..\..\TestProject\Proxy",
//    DotNetProxiesNamespace: "TestProject.Proxy",
//    ModelNamespaces:
//    [(
//        Assembly: typeof(TestProject.Dtos.Company).Assembly,
//        CsNamespace: "TestProject.Dtos",
//        TsNamespace: "interfaces"
//    ),
//    (
//        Assembly: typeof(TestProject.RequestDtos.BaseRequest).Assembly,
//        CsNamespace: "TestProject.RequestDtos",
//        TsNamespace: "interfaces/request"
//    ),
//    (
//        Assembly: typeof(TestProject.ResponseDtos.BaseResponse).Assembly,
//        CsNamespace: "TestProject.ResponseDtos",
//        TsNamespace: "interfaces/response"
//    )],
//    ServiceNamespaces:
//    [(
//        Assembly: typeof(TestProject.Services.CompanyService).Assembly,
//        CsNamespace: "TestProject.Services"
//    )]);

var generator2 = new CodeGenerator.Step2.ApisAndProxies.Generator(config2);
generator2.Run();





