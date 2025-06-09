namespace CodeGenerator.ApiAndProxies.Helpers;

public static class NameHelper
{
    public static string? GetTsType(string propertytype)
    {
        switch (propertytype)
        {
            case "System.Int64":
            case "System.Int32":
            case "System.Double":
            case "System.Byte":
                return "number";
            case "System.String":
                return "string";
            case "System.DateTime":
                return "Date";
            case "System.Boolean":
                return "boolean";
            default:
                return null;
        }
    }
    public static string GetSimpleCsType(string propertytype)
    {
        switch (propertytype)
        {
            case "System.Int64":
                return "long";
            case "System.Int32":
                return "int";
            case "System.String":
                return "string";
            case "System.Double":
                return "double";
            case "System.Boolean":
                return "bool";
            case "System.DateTime":
                return "DateTime";
            case "System.Byte":
                return "byte";
            default:
                throw new ArgumentException($"Unknown type: {propertytype}");
        }
    }
    public static string UpperCaseFirstLetter(string value)
    {
        return value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
    }
    public static string LowerCaseFirstLetter(string value)
    {
        return value.Substring(0, 1).ToLower() + value.Substring(1, value.Length - 1);
    }
}
