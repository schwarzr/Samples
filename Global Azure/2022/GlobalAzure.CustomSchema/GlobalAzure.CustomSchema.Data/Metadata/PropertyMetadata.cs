namespace GlobalAzure.CustomSchema.Data.Metadata
{
    public class PropertyMetadata
    {
        public PropertyMetadata(string name, bool isNullable, PropertyType propertyType)
        {
            Name = name;
            IsNullable = isNullable;
            PropertyType = propertyType;
        }
        public string Name { get; }

        public bool IsNullable { get; }

        public PropertyType PropertyType { get; }
    }
}