using CodeGenerator;
using CodeGenerator.Shared;

var codeGeneratorConfiguration = new GeneratorConfig(
    AngularApiServicesDirectory:        @"..\..\..\..\BeltmanSoftwareDesign.Angular\src\app\apiservices",
    AngularApiServicesDirectoryName:    @"apiservices",
    DotNetControllersDirectory:         @"..\..\..\..\BeltmanSoftwareDesign.Api\Controllers",
    AngularAppDirectory:                @"..\..\..\..\BeltmanSoftwareDesign.Angular\src\app",
    ControllersNamespace:               @"BeltmanSoftwareDesign.Api.Controllers",
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


