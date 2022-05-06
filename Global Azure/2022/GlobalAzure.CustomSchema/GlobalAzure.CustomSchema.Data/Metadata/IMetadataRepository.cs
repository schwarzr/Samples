using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAzure.CustomSchema.Data.Metadata
{
    public interface IMetadataRepository
    {
        MetadataModel GetModel();
    }
}
