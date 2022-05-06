using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure.RestContract.Client
{
    public class CommandInfo<TCommand> : ICommandInfo
        where TCommand : ICommand
    {
        public CommandInfo(string command)
        {
            Command = command;
        }

        public string Command { get; }

        public ICommand Create(IServiceProvider sp)
        {
            return sp.GetRequiredService<TCommand>();
        }
    }
}
