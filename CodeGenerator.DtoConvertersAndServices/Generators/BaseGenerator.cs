namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class BaseGenerator
{
    public DirectoryInfo? Directory { get; protected set; }
    public string? Name { get; protected set; }
    public string? Code { get; protected set; }

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
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }
            File.WriteAllText(filePath, Code);
        }
    }
}