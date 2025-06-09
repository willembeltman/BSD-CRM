using CodeGenerator.ApiAndProxies.Helpers;
using CodeGenerator.ApiAndProxies.Shared;

namespace CodeGenerator.ApiAndProxies;

public class Generator(GeneratorConfig generatorConfig)
{
    public GeneratorConfig Config { get; } = generatorConfig;

    public void Run()
    {
        ExportTsModels();

        ExportTsProxies();
        ExportCsControllers();
        ExportCsProxies();
    }

    private void ExportTsModels()
    {
        foreach (var namespaceItem in Config.ModelNamespaces)
        {
            var huidigeTsFolder = namespaceItem.TsFolder;

            foreach (var model in namespaceItem.Models)
            {
                //import { InvoiceWorkorder } from "./invoiceworkorder";

                //export interface Invoice {
                //    id: number;
                //    invoiceTypeId: number | null;
                //    invoiceTypeName: string | null;
                //    projectId: number | null;
                //    projectName: string | null;
                //    customerId: number | null;
                //    customerName: string | null;
                //    taxRateId: number | null;
                //    taxRateName: string | null;
                //    taxRatePercentage: number | null;
                //    date: string;
                //    invoiceNumber: string | null;
                //    description: string | null;
                //    isPayedInCash: boolean;
                //    isPayed: boolean;
                //    datePayed: string | null;
                //    paymentCode: string | null;
                //    invoiceWorkorders: InvoiceWorkorder[];
                //}

                var text = string.Empty;
                var imports = model.Properties
                    .Select(a => a.TypeRapport)
                    .Where(a => a.Import)
                    .GroupBy(a => a.TsName)
                    .Select(a => a.First())
                    .ToArray();

                foreach (var type in imports)
                {
                    var targetTsFolder = type.Model?.ModelsNamespace?.TsFolder;
                    if (targetTsFolder == null) { continue; }
                    string folder = GetFolderPath(huidigeTsFolder, targetTsFolder);

                    text += "import { " + type.TsName + @" } from """ + folder + type.TsName.ToLower() + @""";" + Environment.NewLine;
                }

                if (imports.Any())
                    text += Environment.NewLine;

                text += @"export interface " + model.Name + " {";
                foreach (var property in model.Properties)
                {
                    text += Environment.NewLine + "    " + property.NameLower + @": " + property.TypeRapport.TsFullName + @";";
                }
                text += Environment.NewLine + "}";

                #region Saven

                var filename = Config.AngularAppDirectory + "\\" + namespaceItem.TsFolder.Replace("/", "\\") + "\\" + model.Name.ToLower() + ".ts";
                WriteToFile(filename, text);
                Console.WriteLine(filename + Environment.NewLine + text + Environment.NewLine);

                #endregion
            }
        }
    }
    private void ExportTsProxies()
    {
        var huidigeTsFolder = Config.AngularApiServicesDirectoryShortName;

        var allmethods = Config.ServiceNamespaces
            .SelectMany(a => a.Services)
            .SelectMany(a => a.Methods);

        var tsServices = allmethods.GroupBy(a => a.TsServiceName);
        foreach (var group2 in tsServices)
        {
            var tsServiceMethods = group2.ToArray();
            var tsServiceName = group2.Key;

            var namespaces1 = tsServiceMethods
                .GroupBy(a => a.ResponseTypeRapport)
                .Select(a => a.Key)
                .Where(a => a.Import)
                .ToArray();
            var namespaces2 = tsServiceMethods
                .GroupBy(a => a.RequestTypeRapport)
                .Select(a => a.Key)
                .Where(a => a.Import)
                .ToArray();
            var namespaces = namespaces1.Concat(namespaces2)
                .GroupBy(a => a)
                .Select(a => a.Key)
                .ToArray();

            //import { Injectable } from '@angular/core';
            //import { Observable } from 'rxjs';
            //import { ConstantsService } from '../services/constants.service';
            //import { HttpClient } from '@angular/common/http';
            //import { LoginResponse } from '../interfaces/response/loginresponse';
            //import { RegisterResponse } from '../interfaces/response/registerresponse';
            //import { LoginRequest } from '../interfaces/request/loginrequest';
            //import { RegisterRequest } from '../interfaces/request/registerrequest';

            //@Injectable({
            //  providedIn: 'root'
            //})
            //export class AuthService
            //{
            //  constructor(private constants:ConstantsService, private http:HttpClient) { }

            //  login(request: LoginRequest): Observable<LoginResponse> {
            //    return this.http.post<LoginResponse>(this.constants.apiUrl + '/auth/login', request);
            //  }
            //  register(request: RegisterRequest): Observable<RegisterResponse> {
            //    return this.http.post<RegisterResponse>(this.constants.apiUrl + '/auth/register', request);
            //  }
            //}

            var text = string.Empty;
            text += @"import { Injectable } from '@angular/core';" + Environment.NewLine;
            text += @"import { Observable } from 'rxjs';" + Environment.NewLine;
            text += @"import { ConstantsService } from '../services/constants.service';" + Environment.NewLine;
            text += @"import { HttpClient } from '@angular/common/http';" + Environment.NewLine;

            foreach (var nnamespace in namespaces)
            {
                if (nnamespace.Model == null) continue;
                var targetTsFolder = nnamespace.Model.ModelsNamespace.TsFolder;
                var folder = GetFolderPath(huidigeTsFolder, targetTsFolder);

                text += $"import {{ {nnamespace.TsName} }} from '{folder}{nnamespace.TsName.ToLower()}';" + Environment.NewLine;
            }

            text += Environment.NewLine;

            text += @"@Injectable({" + Environment.NewLine;
            text += @"  providedIn: 'root'" + Environment.NewLine;
            text += @"})" + Environment.NewLine;
            text += $"export class " + tsServiceName + "Service" + Environment.NewLine;
            text += @"{" + Environment.NewLine;
            text += @"  constructor(private constants:ConstantsService, private http:HttpClient) { }" + Environment.NewLine;
            text += @"  " + Environment.NewLine;

            foreach (var method in tsServiceMethods)
            {
                text += $"  {method.TsMethodName.ToLower()}({method.RequestParameterName}: {method.RequestTypeRapport.TsFullNameNotNull}): Observable<{method.ResponseTypeRapport.TsFullNameNotNull}> {{" + Environment.NewLine;
                text += $"    return this.http.post<{method.ResponseTypeRapport.TsFullNameNotNull}>(this.constants.apiUrl + '/{method.TsServiceName.ToLower()}/{method.TsMethodName.ToLower()}', {method.RequestParameterName});" + Environment.NewLine;
                text += $"  }}" + Environment.NewLine;
            }

            text += @"}" + Environment.NewLine;

            #region Saven

            var filename = Config.AngularApiServicesDirectory + "\\" + NameHelper.LowerCaseFirstLetter(tsServiceName) + ".service.ts";
            WriteToFile(filename, text);

            Console.WriteLine(filename + Environment.NewLine + text + Environment.NewLine);

            #endregion
        }
    }
    private void ExportCsControllers()
    {
        var list = Config.ServiceNamespaces
            .SelectMany(a => a.Services)
            .SelectMany(a => a.Methods);

        var interfaceNamespaces = Config.ServiceNamespaces
            .SelectMany(a => a.Services)
            .SelectMany(a => a.Interfaces)
            .GroupBy(a => a.Namespace)
            .Select(a => a.Key)
            .ToArray();

        var tsServices = list.GroupBy(a => a.TsServiceName);
        foreach (var tsService in tsServices)
        {
            var imports = new List<string>();
            var namespaces1 = tsService.GroupBy(a => a.RequestTypeRapport.Model!.ModelsNamespace.Name).Select(a => a.Key).ToArray();
            var namespaces2 = tsService.GroupBy(a => a.ResponseTypeRapport.Model!.ModelsNamespace.Name).Select(a => a.Key).ToArray();
            var namespaces = namespaces1.Concat(namespaces2).GroupBy(a => a).Select(a => a.Key).ToArray();
            var servicenames = tsService.GroupBy(a => a.Service.Name).Select(a => a.Key).ToArray();


            //using Microsoft.AspNetCore.Mvc;
            //using BeltmanSoftwareDesign.Business.Interfaces;

            //namespace BeltmanSoftwareDesign.Api.Controllers
            //{
            //    [ApiController]
            //    [Route("[controller]/[action]")]
            //    public class AuthController : BaseControllerBase
            //    {
            //        public AuthController(IAuthenticationService authenticationService) 
            //        {
            //            AuthenticationService = authenticationService;
            //        }

            //        public IAuthenticationService AuthenticationService { get; }

            //        [HttpPost]
            //        public LoginResponse? Login(LoginRequest request) 
            //            => AuthenticationService.Login(request);

            //        [HttpPost]
            //        public RegisterResponse? Register(RegisterRequest request) 
            //            => AuthenticationService.Register(request);
            //    }
            //}

            var text = string.Empty;
            text += @"using Microsoft.AspNetCore.Mvc;" + Environment.NewLine;
            foreach (var name in interfaceNamespaces)
            {
                text += $"using {name};" + Environment.NewLine;
            }

            foreach (var name in namespaces)
            {
                text += $"using {name};" + Environment.NewLine;
            }

            text += @"" + Environment.NewLine;
            text += $"namespace {Config.DotNetControllersNamespace};" + Environment.NewLine;
            text += @"" + Environment.NewLine;
            text += @"[ApiController]" + Environment.NewLine;
            text += @"[Route(""[controller]/[action]"")]" + Environment.NewLine;
            text += $"public class {tsService.Key}Controller(";

            var first = true;
            foreach (var servicename in servicenames)
            {
                if (first)
                    first = false;
                else
                    text += ", ";
                text += $"I{servicename} {servicename}";
            }

            text += @") : BaseControllerBase" + Environment.NewLine;
            text += @"{" + Environment.NewLine;


            first = true;
            foreach (var method in tsService)
            {
                if (first)
                    first = false;
                else
                    text += Environment.NewLine;

                if (method.ResponseTypeRapport.Async)
                {
                    //[HttpPost]
                    //public Task<WorkorderCreateResponse> CreateAsync(WorkorderCreateRequest request)
                    //    => WorkorderService.CreateAsync(request);

                    text += $"    [HttpPost]" + Environment.NewLine;
                    text += $"    public async Task<{method.ResponseTypeRapport.Name}> {method.Name}({method.RequestTypeRapport.Name} {method.RequestParameterName}) " + Environment.NewLine;
                    text += $"        => await {method.Service.Name}.{method.Name}({method.RequestParameterName});" + Environment.NewLine;
                }
                else
                {
                    //[HttpPost]
                    //public LoginResponse? Login(LoginRequest request)
                    //    => AuthenticationService.Login(request);

                    text += $"    [HttpPost]" + Environment.NewLine;
                    text += $"    public {method.ResponseTypeRapport.Name} {method.Name}({method.RequestTypeRapport.Name} {method.RequestParameterName}) " + Environment.NewLine;
                    text += $"        => {method.Service.Name}.{method.Name}({method.RequestParameterName});" + Environment.NewLine;
                }
            }

            text += @"}" + Environment.NewLine;

            #region Saven

            var filename = Config.DotNetControllersDirectory + "\\" + tsService.Key + "Controller.cs";
            WriteToFile(filename, text);

            Console.WriteLine(filename + Environment.NewLine + text + Environment.NewLine);

            #endregion
        }
    }
    private void ExportCsProxies()
    {
        var list = Config.ServiceNamespaces
            .SelectMany(a => a.Services)
            .SelectMany(a => a.Methods);

        var interfaceNamespaces = Config.ServiceNamespaces
            .SelectMany(a => a.Services)
            .SelectMany(a => a.Interfaces)
            .GroupBy(a => a.Namespace)
            .Select(a => a.Key)
            .ToArray();

        var tsServices = list.GroupBy(a => a.TsServiceName);
        foreach (var tsService in tsServices)
        {
            var imports = new List<string>();
            var namespaces1 = tsService.GroupBy(a => a.RequestTypeRapport.Model!.ModelsNamespace.Name).Select(a => a.Key).ToArray();
            var namespaces2 = tsService.GroupBy(a => a.ResponseTypeRapport.Model!.ModelsNamespace.Name).Select(a => a.Key).ToArray();
            var namespaces = namespaces1.Concat(namespaces2).GroupBy(a => a).Select(a => a.Key).ToArray();
            var servicenames = tsService.GroupBy(a => a.Service.Name).Select(a => a.Key).ToArray();

            //using BeltmanSoftwareDesign.Shared.RequestJsons;
            //using BeltmanSoftwareDesign.Shared.ResponseJsons;
            //using System.Net.Http.Json;

            //namespace BeltmanSoftwareDesign.Proxy;

            //public class AuthProxy(HttpClient httpClient)
            //{
            //    public async Task<LoginResponse> Login(LoginRequest request)
            //    {
            //        var response = await httpClient.PostAsJsonAsync("/Auth/Login", request);
            //        response.EnsureSuccessStatusCode();

            //        var responseData = await response.Content.ReadFromJsonAsync<LoginResponse>()
            //            ?? throw new Exception("Could not cast response data");

            //        return responseData;
            //    }
            //    public async Task<RegisterResponse> Register(RegisterRequest request)
            //    {
            //        using var response = await httpClient.PostAsJsonAsync("/Auth/Register", request);
            //        response.EnsureSuccessStatusCode();

            //        var responseData = await response.Content.ReadFromJsonAsync<RegisterResponse>()
            //            ?? throw new Exception("Could not cast response data");

            //        return responseData;
            //    }
            //}


            var text = string.Empty;
            text += @"using System.Net.Http.Json;" + Environment.NewLine;
            //foreach (var name in interfaceNamespaces)
            //{
            //    text += $"using {name};" + Environment.NewLine;
            //}

            foreach (var name in namespaces)
            {
                text += $"using {name};" + Environment.NewLine;
            }

            text += @"" + Environment.NewLine;
            text += $"namespace {Config.DotNetProxiesNamespace};" + Environment.NewLine;
            text += @"" + Environment.NewLine;
            text += $"public class {tsService.Key}Proxy(HttpClient httpClient)" + Environment.NewLine;
            text += @"{" + Environment.NewLine;

            var first = true;
            foreach (var method in tsService)
            {
                if (first)
                    first = false;
                else
                    text += Environment.NewLine;

                //    public async Task<LoginResponse> Login(LoginRequest request)
                //    {
                //        var response = await httpClient.PostAsJsonAsync("/Auth/Login", request);
                //        response.EnsureSuccessStatusCode();

                //        var responseData = await response.Content.ReadFromJsonAsync<LoginResponse>()
                //            ?? throw new Exception("Could not cast response data");

                //        return responseData;
                //    }

                text += $"    public async Task<{method.ResponseTypeRapport.Name}> {method.Name}({method.RequestTypeRapport.Name} {method.RequestParameterName}) " + Environment.NewLine;
                text += $"    {{" + Environment.NewLine;
                text += $"        var response = await httpClient.PostAsJsonAsync(\"/{tsService.Key}/{method.Name}\", {method.RequestParameterName});" + Environment.NewLine;
                text += $"        response.EnsureSuccessStatusCode();" + Environment.NewLine;
                text += $"        var responseData = await response.Content.ReadFromJsonAsync<{method.ResponseTypeRapport.Name}>()" + Environment.NewLine;
                text += $"            ?? throw new Exception(\"Could not cast response data\");" + Environment.NewLine;
                text += $"        return responseData;" + Environment.NewLine;
                text += $"    }}" + Environment.NewLine;
            }

            text += @"}" + Environment.NewLine;

            #region Saven

            var filename = Config.DotNetProxiesDirectory + "\\" + tsService.Key + "Proxy.cs";
            WriteToFile(filename, text);

            Console.WriteLine(filename + Environment.NewLine + text + Environment.NewLine);

            #endregion
        }
    }


    private static string GetFolderPath(string huidige, string target)
    {
        var folder = string.Empty;
        if (target.StartsWith(huidige))
        {
            // dieper
            folder = "./" + target.Substring(huidige.Length);
        }
        else
        {
            // via root
            var split1 = huidige.Split('/');
            var split2 = target.Split('/');

            var i = 0;
            for (i = split1.Length; i > 0; i--)
            {
                if (split2.Length >= i)
                {
                    var path1 = string.Join("/", split1.Take(i));
                    var path2 = string.Join("/", split2.Take(i));
                    if (path1 == path2)
                    {
                        break;
                    }
                }
                folder += "../";
            }

            foreach (var item in split2.Skip(i))
            {
                folder += item + "/";
            }
        }

        return folder;
    }



    private static void WriteToFile(string filename, string filecontents)
    {
        var info = new FileInfo(filename);
        if (info.Exists)
        {
            info.Delete();
        }

        using (var stream = File.Create(filename))
        using (var writer = new StreamWriter(stream))
        {
            writer.Write(filecontents);
        }
    }

}
