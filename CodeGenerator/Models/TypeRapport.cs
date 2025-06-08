using CodeGenerator.Helpers;

namespace CodeGenerator.Models
{
    public class TypeRapport
    {
        public TypeRapport(Type type, ModelNamespacesList modelNamespaceList)
        {
            Async = ReflectionHelper.IsAsync(type);
            if (Async)
            {
                type = type.GenericTypeArguments[0];
            }

            Nulleble = ReflectionHelper.IsNulleble(type);
            if (Nulleble && type.GenericTypeArguments.Length > 0)
            {
                type = type.GenericTypeArguments[0];
            }

            var isIEnumerable = ReflectionHelper.IsIEnumerable(type);
            var isArray = ReflectionHelper.IsArray(type);

            List = isIEnumerable || isArray;

            if (isIEnumerable)
            {
                type = type.GenericTypeArguments[0];
            }
            if (isArray)
            {
                type = type.GetElementType()!;
            }

            FullName = type.FullName!;

            TsName = NameHelper.GetTsType(FullName);
            Name = FullName;
            if (TsName == null)
            {
                var models = modelNamespaceList.List.SelectMany(a => a.Models).ToArray();
                foreach (var model in models)
                {
                    if (model.FullName == FullName)
                    {
                        Model = model;
                        TsName = FullName.Substring(
                            model.ModelsNamespace.Name.Length + 1,
                            FullName.Length - model.ModelsNamespace.Name.Length - 1);
                        Name = TsName;
                        break;
                    }
                }
            }
            if (TsName == null)
                throw new Exception("Cannot find type in models");

            Import = Model != null;

            if (!List && (FullName == "System.String" || Import))
            {
                Nulleble = true;
            }
        }

        public string FullName { get; }
        public string Name { get; }
        public string TsName { get; set; }
        public bool Async { get; }
        public bool Nulleble { get; set; }
        public bool List { get; set; }
        public bool Import { get; set; }
        public Model? Model { get; set; }

        public string TsFullNameNotNull =>
            TsName + (List ? "[]" : "");
        public string TsFullName =>
            TsFullNameNotNull + (Nulleble && !List ? " | null" : "");
    }
}