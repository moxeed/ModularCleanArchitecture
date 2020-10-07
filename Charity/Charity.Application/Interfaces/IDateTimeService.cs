using System;

namespace Charity.Application.Module.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
