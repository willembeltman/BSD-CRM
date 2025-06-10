namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class BaseGenerator
{
    public DirectoryInfo? Directory { get; protected set; }
    public string? Namespace { get; protected set; }
    public string? Name { get; protected set; }
    public string? Code { get; protected set; }

    public string FullName => $"{Namespace}.{Name}";

    public string AddNamespace(string usingCode, string @using)
    {
        if (!usingCode.Contains(@using))
        {
            usingCode += $"{@using}\r\n";
        }
        return usingCode;
    }

    public void Save(bool overwrite = true)
    {
        if (Directory == null || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Code))
        {
            throw new InvalidOperationException("Directory, Name, and Code must be set before saving.");
        }
        var filePath = Path.Combine(Directory.FullName, $"{Name}.cs");
        var fileInfo = new FileInfo(filePath);
        if (overwrite || !fileInfo.Exists)
        {
            if (!fileInfo.Directory!.Exists)
            {
                fileInfo.Directory.Create();
            }
            File.WriteAllText(filePath, Code);
        }
    }
}