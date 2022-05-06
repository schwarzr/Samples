using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAzure.RestContract.Data.Model
{
    public class ToDoItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Completed { get; set; }
    }
}
