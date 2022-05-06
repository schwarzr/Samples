using System.Text.Json;
using Codeworx.Rest.Client;
using GlobalAzure.RestContract.Data;

namespace GlobalAzure.RestContract.Client.Commands
{
    public class ListCommand : ICommand
    {
        private readonly RestClient<IToDoService> _client;

        public ListCommand(RestClient<IToDoService> client)
        {
            _client = client;
        }

        public async Task ProcessAsync(string[] args)
        {
            var data = await _client.CallAsync(p => p.GetItemsAsync());

            foreach (var item in data)
            {
                Console.WriteLine(JsonSerializer.Serialize(item));
            }
        }
    }
}
