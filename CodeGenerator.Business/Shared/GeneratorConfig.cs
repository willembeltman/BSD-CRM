using CodeGenerator.Models;
using CodeGenerator.Services;
using System.Reflection;

namespace CodeGenerator.Shared;

public class GeneratorConfig
{
    public string AngularApiServicesDirectory { get; }
    public string AngularApiServicesDirectoryName { get; }
    public string DotNetControllersDirectory { get; }
    public string AngularAppDirectory { get; }
    public string ControllersNamespace { get; }
    public ModelNamespace[] ModelNamespaces { get; }
    public ServiceNamespace[] ServiceNamespaces { get; }

    public GeneratorConfig(
        string AngularApiServicesDirectory,
        string AngularApiServicesDirectoryName,
        string DotNetControllersDirectory,
        string AngularAppDirectory,
        string ControllersNamespace,
        (Assembly Assembly, string CsNamespace, string TsNamespace)[] ModelNamespaces,
        (Assembly Assembly, string CsNamespace)[] ServiceNamespaces)
    {
        this.AngularApiServicesDirectory = AngularApiServicesDirectory;
        this.AngularApiServicesDirectoryName = AngularApiServicesDirectoryName;
        this.DotNetControllersDirectory = DotNetControllersDirectory;
        this.AngularAppDirectory = AngularAppDirectory;
        this.ControllersNamespace = ControllersNamespace;
        this.ModelNamespaces = ModelNamespaces
            .Select(a => new ModelNamespace(this, a.Assembly, a.CsNamespace, a.TsNamespace))
            .ToArray();
        this.ServiceNamespaces = ServiceNamespaces
            .Select(a => new ServiceNamespace(this, a.Assembly, a.CsNamespace))
            .ToArray();
    }
}
