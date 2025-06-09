using CodeGenerator.Helpers;

namespace CodeGenerator;

public class WeetIkVeel
{
    private void ExportServices(ControllerMethodList list)
    {
        var huidigeTsNamespace = "apiservices";

        var controllerMethodGroups = list.ControllerMethods.GroupBy(a => a.ServiceName);
        foreach (var controllerMethodGroup in controllerMethodGroups)
        {
            var header = string.Empty;
            header += @"import { Injectable } from '@angular/core';" + Environment.NewLine;
            header += @"import { Observable } from 'rxjs';" + Environment.NewLine;
            header += @"import { ConstantsService } from '../services/constants.service';" + Environment.NewLine;
            header += @"import { HttpClient } from '@angular/common/http';" + Environment.NewLine;

            var body = string.Empty;
            body += @"@Injectable({" + Environment.NewLine;
            body += @"  providedIn: 'root'" + Environment.NewLine;
            body += @"})" + Environment.NewLine;
            body += $"export class " + controllerMethodGroup.Key + "Service" + Environment.NewLine;
            body += @"{" + Environment.NewLine;
            body += @"  constructor(private constants:ConstantsService, private http:HttpClient) { }" + Environment.NewLine;
            body += @"  " + Environment.NewLine;

            var imports = new List<string>();

            foreach (var controllerMethod in controllerMethodGroup)
            {
                if (controllerMethod.ReturnTypeImport)
                {
                    if (!imports.Contains(controllerMethod.ReturnTsType))
                    {
                        imports.Add(controllerMethod.ReturnTsType);

                        var target = controllerMethod.ReturnTypeImportNamespace.TsFolder;
                        var folder = GetFolderPath(huidigeTsNamespace, target);

                        header +=
                            "import { " +
                            controllerMethod.ReturnTsType +
                            " } from '" +
                            folder + controllerMethod.ReturnTsType.ToLower() +
                            "';" + Environment.NewLine;
                    }
                }

                var parameter = controllerMethod.Parameters.First();
                if (parameter.Import)
                {
                    if (!imports.Contains(parameter.TsType))
                    {
                        imports.Add(parameter.TsType);

                        var targetTsNamespace = parameter.ImportNamespace.TsFolder;
                        var folder = GetFolderPath(huidigeTsNamespace, targetTsNamespace);

                        header +=
                            "import { " +
                            parameter.TsType +
                            " } from '" +
                            folder + parameter.TsType.ToLower() +
                            "';" + Environment.NewLine;
                    }
                }

                body += $"  " + controllerMethod.ServiceMethod.ToLower() + "(" +
                    $"{parameter.Name}: {parameter.TsType}" + (parameter.IsList ? "[]" : "") +
                    @"): Observable<" +
                    controllerMethod.ReturnTsType + (controllerMethod.ReturnTypeIsList ? "[]" : "") +
                    "> {" + Environment.NewLine;

                body += @"    return this.http.post<" +
                    controllerMethod.ReturnTsType + (controllerMethod.ReturnTypeIsList ? "[]" : "") +
                    ">(this.constants.apiUrl + '/" +
                    controllerMethod.ControllerName + "', " +
                    parameter.Name + ");" + Environment.NewLine;

                body += @"  }" + Environment.NewLine;

            }

            body += @"}" + Environment.NewLine;

            var filename = angular_services + "\\" + NameHelper.LowerCaseFirstLetter(controllerMethodGroup.Key) + ".service.ts";
            var filecontents = header + Environment.NewLine + Environment.NewLine + body;

            WriteToFile(filename, filecontents);

            Console.WriteLine(filename + Environment.NewLine + filecontents + Environment.NewLine);
        }
    }
}