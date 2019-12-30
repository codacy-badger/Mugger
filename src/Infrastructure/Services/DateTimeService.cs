using Mugger.Application.Common.Interfaces;
using System;

namespace Mugger.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
