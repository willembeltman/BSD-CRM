namespace CodeGenerator.Services;

public class Service
{
    static string ServiceNameEnd = "Service";

    public Service(ServiceNamespace servicesNamespace, Type type)
    {
        ServicesNamespace = servicesNamespace;

        if (type == null) throw new ArgumentNullException(nameof(type));
        if (type.FullName == null) throw new ArgumentException("Type must have a full name.", nameof(type));

        Fullname = type.FullName;
        NameWithService = type.Name;
        if (NameWithService.ToLower().EndsWith(ServiceNameEnd.ToLower()))
            Name = NameWithService
                .Substring(0, NameWithService.Length - ServiceNameEnd.Length);

        Methods = type
            .GetMethods()
            .Where(a => a.CustomAttributes.Any(b => b.AttributeType.Name == "TsServiceMethodAttribute"))
            .Select(a => new ServiceMethod(this, a))
            .ToArray();

        Interfaces = type
            .GetInterfaces()
            .Select(a => new ServiceInterface(this, a))
            .ToArray();
    }

    public ServiceNamespace ServicesNamespace { get; }
    public string Fullname { get; }
    public string NameWithService { get; }
    public string Name { get; }
    public ServiceMethod[] Methods { get; }
    internal ServiceInterface[] Interfaces { get; }

    public override string ToString()
    {
        return Name;
    }
}
