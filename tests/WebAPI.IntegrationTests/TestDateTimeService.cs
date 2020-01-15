using Mugger.Application.Common.Interfaces;
using System;

namespace Mugger.WebAPI.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
