using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAzure.RestContract.Client
{
    public interface ICommandInfo
    {
        string Command { get; }

        ICommand Create(IServiceProvider sp);
    }
}
