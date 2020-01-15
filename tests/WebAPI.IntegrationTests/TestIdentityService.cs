using Mugger.Application.Common.Interfaces;
using Mugger.Application.Common.Models;
using System;
using System.Threading.Tasks;

namespace Mugger.WebAPI.IntegrationTests
{
    public class TestIdentityService : IIdentityService
    {
        public Task<string> GetUserNameAsync(string userId)
        {
            return Task.FromResult("bob@mugger.nl");
        }

        public Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}