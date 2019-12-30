using Microsoft.AspNetCore.Http;
using Mugger.Application.Common.Interfaces;
using System.Security.Claims;

namespace Mugger.WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}

