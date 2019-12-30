using Microsoft.AspNetCore.Identity;
using Mugger.Infrastructure.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Mugger.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "bob@mugger.nl", Email = "bob@mugger.nl" };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, "Mugger!");
            }
        }
    }
}
