namespace CodeGenerator.ApiAndProxies.Services;

public class ServiceInterface
{
    public Service Service { get; }
    public string Name { get; }
    public string FullName { get; }
    public string Namespace { get; }

    public ServiceInterface(Service service, Type type)
    {
        Service = service;
        Name = type.Name ?? throw new ArgumentException("Type must have a name.", nameof(type));
        FullName = type.FullName ?? throw new ArgumentException("Type must have a full name.", nameof(type));
        Namespace = type.Namespace ?? throw new ArgumentException("Type must have a namespace.", nameof(type));
    }
}