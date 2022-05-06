using System.Collections.Generic;

namespace GlobalAzure.CustomSchema.Data
{
    public interface IExtendableObject
    {
        public Dictionary<string, object> AdditionalProperties { get; set; }
    }
}
