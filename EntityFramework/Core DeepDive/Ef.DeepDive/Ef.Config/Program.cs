using System;
using System.Threading.Tasks;
using Ef.Config.Jobs;

namespace Ef.Config
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var job = new Demo4();
            await job.ProcessAsync();

            Console.ReadLine();
        }
    }
}
