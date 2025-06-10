
using BSD.Data;

var config1 = new CodeGenerator.DtoConvertersAndServices.GeneratorConfig(
    typeof(ApplicationDbContext),
    new DirectoryInfo("..\\..\\..\\..\\BSD.Shared\\Dtos"), "BSD.Shared.Dtos",
    new DirectoryInfo("..\\..\\..\\..\\BSD.Shared\\RequestDtos"), "BSD.Shared.RequestDtos",
    new DirectoryInfo("..\\..\\..\\..\\BSD.Shared\\ResponseDtos"), "BSD.Shared.ResponseDtos",
    new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\Converters"), "BSD.Business.Converters",
    new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\Interfaces"), "BSD.Business.Interfaces",
    new DirectoryInfo("..\\..\\..\\..\\BSD.Business\\Services"), "BSD.Business.Services");
var generator1 = new CodeGenerator.DtoConvertersAndServices.Generator(config1);
generator1.Run();


//var config2 = new CodeGenerator.ApiAndProxies.Shared.GeneratorConfig(
//    AngularAppDirectory: @"..\..\..\..\BSD.Angular\src\app",
//    AngularApiServicesDirectory: @"..\..\..\..\BSD.Angular\src\app\apiservices",
//    AngularApiServicesDirectoryShortName: "apiservices",
//    DotNetControllersDirectory: @"..\..\..\..\BSD.Api\Controllers",
//    DotNetControllersNamespace: "BSD.Api.Controllers",
//    DotNetProxiesDirectory: @"..\..\..\..\BSD.Proxy",
//    DotNetProxiesNamespace: "BSD.Proxy",
//    ModelNamespaces:
//        [(
//            Assembly:                       typeof(BSD.Shared.Dtos.Company).Assembly,
//            CsNamespace:                    "BSD.Shared.Dtos",
//            TsNamespace:                    "interfaces"
//        ),
//        (
//            Assembly:                       typeof(BSD.Shared.RequestDtos.LoginRequest).Assembly,
//            CsNamespace:                    "BSD.Shared.Requests",
//            TsNamespace:                    "interfaces/request"
//        ),
//        (
//            Assembly:                       typeof(BSD.Shared.ResponseDtos.LoginResponse).Assembly,
//            CsNamespace:                    "BSD.Shared.Responses",
//            TsNamespace:                    "interfaces/response"
//        )],
//    ServiceNamespaces:
//        [(
//            Assembly:                       typeof(BSD.Business.Services.AuthenticationService).Assembly,
//            CsNamespace:                    "BSD.Business.Services"
//        )]);
//var generator2 = new CodeGenerator.ApiAndProxies.Generator(config2);
//generator2.Run();





