using System;

namespace LargeDate.Contract
{
    public interface ITrackable
    {
        TimeSpan LastRequestDuration { get; }
        int LastRequestSize { get; }
    }
}