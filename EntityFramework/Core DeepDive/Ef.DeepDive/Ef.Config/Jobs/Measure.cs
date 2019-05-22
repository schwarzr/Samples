using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Ef.Config.Jobs
{
    public class Measure : IDisposable
    {
        private readonly Stopwatch _stopwatch;

        public Measure()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            Console.WriteLine($"Started: {DateTime.Now}");
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            Console.WriteLine($"Stopped: Took - {_stopwatch.Elapsed}");
        }
    }
}
