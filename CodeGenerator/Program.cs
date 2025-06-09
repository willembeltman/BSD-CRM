using BSD.Data;
using CodeGenerator.ApiAndProxies;
using CodeGenerator.ApiAndProxies.Shared;

var generator2 = new CodeGenerator.DtoConvertersAndServices.Generator();
generator2.GenerateCode(typeof(ApplicationDbContext), "", "", "", "", "", "");

var codeGeneratorConfiguration = new GeneratorConfig(
    AngularAppDirectory:                    @"..\..\..\..\BSD.Angular\src\app",
    AngularApiServicesDirectory:            @"..\..\..\..\BSD.Angular\src\app\apiservices",
    AngularApiServicesDirectoryShortName:   "apiservices",
    DotNetControllersDirectory:             @"..\..\..\..\BSD.Api\Controllers",
    DotNetControllersNamespace:             "BSD.Api.Controllers",
    DotNetProxiesDirectory:                 @"..\..\..\..\BSD.Proxy",
    DotNetProxiesNamespace:                 "BSD.Proxy",
    ModelNamespaces:
        [(
            Assembly:                       typeof(BSD.Shared.Dtos.Company).Assembly,
            CsNamespace:                    "BSD.Shared.Dtos",
            TsNamespace:                    "interfaces"
        ),
        (
            Assembly:                       typeof(BSD.Shared.Requests.LoginRequest).Assembly,
            CsNamespace:                    "BSD.Shared.Requests",
            TsNamespace:                    "interfaces/request"
        ),
        (
            Assembly:                       typeof(BSD.Shared.Responses.LoginResponse).Assembly,
            CsNamespace:                    "BSD.Shared.Responses",
            TsNamespace:                    "interfaces/response"
        )],
    ServiceNamespaces:
        [(  
            Assembly:                       typeof(BSD.Business.Services.AuthenticationService).Assembly,
            CsNamespace:                    "BSD.Business.Services"
        )]);

Generator app = new Generator(codeGeneratorConfiguration);
app.Run();


