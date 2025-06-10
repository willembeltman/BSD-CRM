
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
    serviceHandlersDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\ServiceHandlers"),
    serviceHandlersNamespace: "BSD.Business.ServiceHandlers",
    interfacesDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\Interfaces"),
    interfacesNamespace: "BSD.Business.Interfaces",
    servicesDirectory: new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\Services"),
    servicesNamespace: "BSD.Business.Services");
var generator1 = new CodeGenerator.Step1.DtosConvertersAndServices.Generator(config1);
generator1.Run();


//var config2 = new CodeGenerator.Step2.ApisAndProxies.GeneratorConfig(
//    AngularAppDirectory: @"..\..\..\..\BSD.Angular\src\app",
//    AngularApiServicesDirectory: @"..\..\..\..\BSD.Angular\src\app\apiservices",
//    AngularApiServicesTsNamespace: "apiservices",
//    DotNetControllersDirectory: @"..\..\..\..\BSD.Api\Controllers",
//    DotNetControllersNamespace: "BSD.Api.Controllers",
//    DotNetProxiesDirectory: @"..\..\..\..\BSD.Proxy",
//    DotNetProxiesNamespace: "BSD.Proxy",
//    ModelNamespaces:
//    [(
//        Assembly: typeof(BSD.Shared.Dtos.Company).Assembly,
//        CsNamespace: "BSD.Shared.Dtos",
//        TsNamespace: "interfaces"
//    ),
//    (
//        Assembly: typeof(BSD.Shared.RequestDtos.LoginRequest).Assembly,
//        CsNamespace: "BSD.Shared.Requests",
//        TsNamespace: "interfaces/request"
//    ),
//    (
//        Assembly: typeof(BSD.Shared.ResponseDtos.LoginResponse).Assembly,
//        CsNamespace: "BSD.Shared.Responses",
//        TsNamespace: "interfaces/response"
//    )],
//    ServiceNamespaces:
//    [(
//        Assembly: typeof(BSD.Business.Services.AuthenticationService).Assembly,
//        CsNamespace: "BSD.Business.Services"
//    )]);
//var generator2 = new CodeGenerator.Step2.ApisAndProxies.Generator(config2);
//generator2.Run();





