using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Movielandia.Data;
using Movielandia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movielandia.Common.Middlewares
{
    public class SeedAdminMiddleware
    {
        private readonly RequestDelegate next;

        public SeedAdminMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(
            HttpContext context,
            MovielandiaDbContext dbContext,
            UserManager<MovielandiaUser> usermanager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!dbContext.Roles.Any())
            {
                await this.SeedAdmin(usermanager, roleManager);
            }

            await this.next(context);
        }

        private async Task SeedAdmin(UserManager<MovielandiaUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            bool IsAdminRoleCreated = await roleManager.RoleExistsAsync("Admin");
            if (!IsAdminRoleCreated)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);
            }

            var user = new MovielandiaUser();
            user.UserName = "admin";
            user.MovielandiaUsername = "admin";
            user.Email = "admin@admin.com";
            user.FirstName = "admin";
            user.LastName = "admin";
            user.Address = "admin";


            var userPassword = "123";

            IdentityResult IsUserCreated = await userManager.CreateAsync(user, userPassword);

            if (IsUserCreated.Succeeded)
            {
                var result1 = await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
