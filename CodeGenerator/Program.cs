using CodeGenerator;
using CodeGenerator.Shared;

var codeGeneratorConfiguration = new GeneratorConfig(
    AngularAppDirectory:                    @"..\..\..\..\BeltmanSoftwareDesign.Angular\src\app",
    AngularApiServicesDirectory:            @"..\..\..\..\BeltmanSoftwareDesign.Angular\src\app\apiservices",
    AngularApiServicesDirectoryShortName:   "apiservices",
    DotNetControllersDirectory:             @"..\..\..\..\BeltmanSoftwareDesign.Api\Controllers",
    DotNetControllersNamespace:             "BeltmanSoftwareDesign.Api.Controllers",
    DotNetProxiesDirectory:                 @"..\..\..\..\BeltmanSoftwareDesign.Proxy",
    DotNetProxiesNamespace:                 "BeltmanSoftwareDesign.Proxy",
    ModelNamespaces:
        [(
            Assembly:                       typeof(BeltmanSoftwareDesign.Shared.Dtos.Company).Assembly,
            CsNamespace:                    "BeltmanSoftwareDesign.Shared.Dtos",
            TsNamespace:                    "interfaces"
        ),
        (
            Assembly:                       typeof(BeltmanSoftwareDesign.Shared.Requests.LoginRequest).Assembly,
            CsNamespace:                    "BeltmanSoftwareDesign.Shared.Requests",
            TsNamespace:                    "interfaces/request"
        ),
        (
            Assembly:                       typeof(BeltmanSoftwareDesign.Shared.Responses.LoginResponse).Assembly,
            CsNamespace:                    "BeltmanSoftwareDesign.Shared.Responses",
            TsNamespace:                    "interfaces/response"
        )],
    ServiceNamespaces:
        [(  
            Assembly:                       typeof(BeltmanSoftwareDesign.Business.Services.AuthenticationService).Assembly,
            CsNamespace:                    "BeltmanSoftwareDesign.Business.Services"
        )]);

Generator app = new Generator(codeGeneratorConfiguration);
app.Run();


