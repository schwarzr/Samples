using Codeworx.Rest.Client;
using GlobalAzure.RestContract.Client.Commands;
using GlobalAzure.RestContract.Controllers;
using GlobalAzure.RestContract.Data;
using GlobalAzure.RestContract.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddRestClient("https://localhost:7185/")
    .AddRestProxies(typeof(Program).Assembly);

//serviceCollection.AddDbContext<ToDoContext>(p => p.UseSqlite(@"Data Source=c:\Temp\todo.sqlite", p => p.MigrationsAssembly("GlobalAzure.RestContract.Sqlite")));
//serviceCollection.AddScoped<IToDoService, ToDoController>();

serviceCollection.AddCommand<ListCommand>("list");
serviceCollection.AddCommand<GetCommand>("get");

var services = serviceCollection.BuildServiceProvider();

Console.WriteLine("Ready!");
Console.Write('>');

var command = Console.ReadLine();
while (command != null && command != "exit")
{
    var split = command.Split(' ');
    using (var scope = services.CreateScope())
    {
        var cmd = scope.ServiceProvider.GetCommand(split[0]);
        if (cmd != null)
        {
            await cmd.ProcessAsync(split.Skip(1).ToArray());
        }
    }
    Console.WriteLine();
    Console.Write('>');
    command = Console.ReadLine();
}