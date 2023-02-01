using HrSystem.Common;
using HrSystem.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace HrSystem.Data.Seeding
{
    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            await SeedAdminAsync(userManager);
            await SeedApplicantUserAsync(userManager);
            await SeedHrAsync(userManager);
        }

        private static async Task SeedAdminAsync(UserManager<IdentityUser> userManager)
        {
            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != admin.Id))
            {
                var user = await userManager.FindByEmailAsync(admin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(admin, "123456");
                    await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
                }
            }
        }

        private static async Task SeedApplicantUserAsync(UserManager<IdentityUser> userManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "applicantuser@gmail.com",
                Email = "applicantuser@gmail.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123456");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Applicant.ToString());
                }
            }
        }

        private static async Task SeedHrAsync(UserManager<IdentityUser> userManager)
        {
            var hr = new IdentityUser
            {
                UserName = "hr@gmail.com",
                Email = "hr@gmail.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != hr.Id))
            {
                var user = await userManager.FindByEmailAsync(hr.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(hr, "123456");
                    await userManager.AddToRoleAsync(hr, Roles.Hr.ToString());
                }
            }
        }
    }
}
