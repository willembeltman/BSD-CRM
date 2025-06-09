namespace CodeGenerator.Library.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
    public class TsHiddenAttribute : Attribute
    {
    }
}
