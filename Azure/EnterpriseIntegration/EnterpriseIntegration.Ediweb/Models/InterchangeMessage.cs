using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseIntegration.Ediweb.Models
{
    public class InterchangeMessage
    {
        public string InterchangeId { get; set; }

        public string RecipientId { get; set; }

        public string SenderId { get; set; }

        public DateTime SendTime { get; set; }
    }
}