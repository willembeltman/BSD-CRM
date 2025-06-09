namespace CodeGenerator.Shared.Interfaces;

public interface IProperty
{
    bool IsArray { get; set; }
    bool IsAsync { get; set; }
    bool IsICollection { get; set; }
    bool IsIEnumerable { get; set; }
    bool IsList { get; set; }
    bool IsLijst { get; set; }
    bool IsNullable { get; set; }
}