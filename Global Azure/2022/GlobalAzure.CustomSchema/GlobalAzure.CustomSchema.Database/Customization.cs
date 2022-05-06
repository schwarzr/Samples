using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAzure.CustomSchema.Database
{
    public class Customization
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string Metadata { get; set; }
    }
}
