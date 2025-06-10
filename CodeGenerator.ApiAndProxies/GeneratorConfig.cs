using CodeGenerator.Step2.ApiAndProxies.Models;
using CodeGenerator.Step2.ApiAndProxies.Services;
using System.Reflection;

namespace CodeGenerator.Step2.ApisAndProxies;

public class GeneratorConfig
{
    public string AngularAppDirectory { get; }
    public string AngularApiServicesDirectory { get; }
    public string AngularApiServicesDirectoryShortName { get; }
    public string DotNetControllersDirectory { get; }
    public string DotNetControllersNamespace { get; }
    public string DotNetProxiesDirectory { get; }
    public string DotNetProxiesNamespace { get; }

    public ModelNamespace[] ModelNamespaces { get; }
    public ServiceNamespace[] ServiceNamespaces { get; }

    public GeneratorConfig(
        string AngularAppDirectory,
        string AngularApiServicesDirectory,
        string AngularApiServicesTsNamespace,
        string DotNetControllersDirectory,
        string DotNetControllersNamespace,
        string DotNetProxiesDirectory,
        string DotNetProxiesNamespace,
        (Assembly Assembly, string CsNamespace, string TsNamespace)[] ModelNamespaces,
        (Assembly Assembly, string CsNamespace)[] ServiceNamespaces)
    {
        this.AngularApiServicesDirectory = AngularApiServicesDirectory;
        this.AngularApiServicesDirectoryShortName = AngularApiServicesTsNamespace;
        this.DotNetControllersDirectory = DotNetControllersDirectory;
        this.AngularAppDirectory = AngularAppDirectory;
        this.DotNetControllersNamespace = DotNetControllersNamespace;
        this.DotNetProxiesDirectory = DotNetProxiesDirectory;
        this.DotNetProxiesNamespace = DotNetProxiesNamespace;

        this.ModelNamespaces = ModelNamespaces
            .Select(a => new ModelNamespace(this, a.Assembly, a.CsNamespace, a.TsNamespace))
            .ToArray();
        this.ServiceNamespaces = ServiceNamespaces
            .Select(a => new ServiceNamespace(this, a.Assembly, a.CsNamespace))
            .ToArray();
    }
}
