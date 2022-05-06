namespace GlobalAzure.CustomSchema.Data.Metadata
{
    public class EntityMetadata
    {
        public EntityMetadata(string entityName, IList<PropertyMetadata> properties)
        {
            EntityName = entityName;
            Properties = properties.ToList();
        }

        public string EntityName { get; }

        public IList<PropertyMetadata> Properties { get; }
    }
}