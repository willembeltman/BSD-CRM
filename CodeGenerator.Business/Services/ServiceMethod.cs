using CodeGenerator.Helpers;
using CodeGenerator.Shared;
using System.Reflection;

namespace CodeGenerator.Services;

public class ServiceMethod
{
    public ServiceMethod(Service service, MethodInfo method)
    {
        Service = service;

        Name = method.Name;
        _ResponseType = method.ReturnType;

        var serviceandmethod = method.CustomAttributes
            .FirstOrDefault(b =>
                b.AttributeType.Name == "TsServiceMethodAttribute");
        if (serviceandmethod == null)
            throw new Exception("No TsServiceMethodAttribute found");

        TsServiceName = NameHelper.UpperCaseFirstLetter(serviceandmethod.ConstructorArguments.FirstOrDefault().ToString().Replace("\"", ""));
        TsMethodName = serviceandmethod.ConstructorArguments.LastOrDefault().ToString().Replace("\"", "");

        var parameters = method.GetParameters();
        if (parameters.Length > 1)
            throw new Exception("Too many parameters");
        if (parameters == null || parameters.Length == 0)
            throw new Exception("No parameters found");

        RequestParameterName = parameters[0].Name!;
        _RequestParameterType = parameters[0].ParameterType;
    }

    public Service Service { get; }

    public string Name { get; }
    //public string PublicName { get; }
    public string TsServiceName { get; }
    public string TsMethodName { get; }
    public string RequestParameterName { get; }

    Type _RequestParameterType { get; }
    Type _ResponseType { get; }

    TypeRapport? _RequestTypeRapport { get; set; }
    public TypeRapport RequestTypeRapport
    {
        get
        {
            if (_RequestTypeRapport == null)
                _RequestTypeRapport = new TypeRapport(_RequestParameterType, Service.ServicesNamespace.NamespacesList);
            return _RequestTypeRapport;
        }
    }

    TypeRapport? _ResponseTypeRapport { get; set; }
    public TypeRapport ResponseTypeRapport
    {
        get
        {
            if (_ResponseTypeRapport == null)
                _ResponseTypeRapport = new TypeRapport(_ResponseType, Service.ServicesNamespace.NamespacesList);
            return _ResponseTypeRapport;
        }
    }

    public override string ToString()
    {
        return Name;
    }
}
