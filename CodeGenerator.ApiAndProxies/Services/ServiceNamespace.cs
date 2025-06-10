using CodeGenerator.Shared.Attributes;
using System.Reflection;
using CodeGenerator.Step2.ApisAndProxies;

namespace CodeGenerator.Step2.ApiAndProxies.Services
{
    public class ServiceNamespace
    {
        public ServiceNamespace(GeneratorConfig servicesNamespacesList, Assembly assembly, string name)
        {
            NamespacesList = servicesNamespacesList;
            Name = name;

            Services = assembly
                .GetTypes()
                .Where(a =>
                    a.IsVisible &&
                    a.Namespace == name &&
                    !a.CustomAttributes.Any(b => b.AttributeType.Name == nameof(TsHiddenAttribute)))
                .Select(a => new Service(this, a))
                .ToArray();
        }

        public GeneratorConfig NamespacesList { get; }
        public string Name { get; }
        public Service[] Services { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
