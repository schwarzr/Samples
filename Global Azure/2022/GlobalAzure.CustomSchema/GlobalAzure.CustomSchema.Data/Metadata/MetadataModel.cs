namespace GlobalAzure.CustomSchema.Data.Metadata
{
    public class MetadataModel
    {
        public MetadataModel(int version, IEnumerable<EntityMetadata> entities)
        {
            Version = version;
            Entities = entities.ToList();
        }

        public int Version { get; }

        public List<EntityMetadata> Entities { get; }
    }
}