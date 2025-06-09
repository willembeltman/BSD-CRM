using CodeGenerator;
using CodeGenerator.Shared;

var codeGeneratorConfiguration = new GeneratorConfig(
    AngularAppDirectory:                    @"..\..\..\..\BeltmanSoftwareDesign.Angular\src\app",
    AngularApiServicesDirectory:            @"..\..\..\..\BeltmanSoftwareDesign.Angular\src\app\apiservices",
    AngularApiServicesDirectoryShortName:   @"apiservices",
    DotNetControllersDirectory:             @"..\..\..\..\BeltmanSoftwareDesign.Api\Controllers",
    DotNetControllersNamespace:             @"BeltmanSoftwareDesign.Api.Controllers",
    DotNetProxiesDirectory:                 @"..\..\..\..\BeltmanSoftwareDesign.Proxy",
    DotNetProxiesNamespace:                 @"BeltmanSoftwareDesign.Proxy",
    ModelNamespaces:
        [(
            Assembly:                   typeof(BeltmanSoftwareDesign.Shared.Jsons.Company).Assembly,
            CsNamespace:                @"BeltmanSoftwareDesign.Shared.Jsons",
            TsNamespace:                @"interfaces"
        ),
        (
            Assembly:                   typeof(BeltmanSoftwareDesign.Shared.RequestJsons.LoginRequest).Assembly,
            CsNamespace:                @"BeltmanSoftwareDesign.Shared.RequestJsons",
            TsNamespace:                @"interfaces/request"
        ),
        (
            Assembly:                   typeof(BeltmanSoftwareDesign.Shared.ResponseJsons.LoginResponse).Assembly,
            CsNamespace:                @"BeltmanSoftwareDesign.Shared.ResponseJsons",
            TsNamespace:                @"interfaces/response"
        )
        ],
    ServiceNamespaces:
        [(  Assembly:               typeof(BeltmanSoftwareDesign.Business.Services.AuthenticationService).Assembly,
            CsNamespace:            "BeltmanSoftwareDesign.Business.Services")
        ]);

Generator app = new Generator(codeGeneratorConfiguration);
app.Run();


