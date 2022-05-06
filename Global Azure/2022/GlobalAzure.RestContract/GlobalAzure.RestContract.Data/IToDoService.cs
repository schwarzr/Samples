using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codeworx.Rest;
using GlobalAzure.RestContract.Data.Model;

namespace GlobalAzure.RestContract.Data
{
    [RestRoute("api/todo")]
    public interface IToDoService
    {
        [RestGet()]
        Task<IEnumerable<ToDoItem>> GetItemsAsync();

        [RestGet("{name}")]
        Task<ToDoDetailItem> GetItemByNameAsync(string name);
    }
}
