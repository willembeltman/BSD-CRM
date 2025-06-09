using CodeGenerator.Entities.Models;

namespace CodeGenerator.Entities.Template
{
    public class JsonClass
    {
        public JsonClass(EntityInfo entity)
        {
            Entity = entity;
        }

        public EntityInfo Entity { get; }

        public string Get()
        {
            return null;
        }
    }
}
