using System;
using Charity.Application.Module.Interfaces;

namespace Charity.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
