using System.Text.Json;
using Codeworx.Rest.Client;
using GlobalAzure.RestContract.Data;

namespace GlobalAzure.RestContract.Client.Commands
{
    public class GetCommand : ICommand
    {
        private readonly IToDoService _client;

        public GetCommand(IToDoService client)
        {
            _client = client;
        }

        public async Task ProcessAsync(string[] args)
        {
            var data = await _client.GetItemByNameAsync(args[0]);

            Console.WriteLine(JsonSerializer.Serialize(data));
        }
    }
}
