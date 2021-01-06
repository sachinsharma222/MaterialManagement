using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(UserManager<IdentityUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                string adminPass = "Admin@123";
                var result = userManager.CreateAsync(new IdentityUser
                {
                    Email = "admin@portal.com",
                    UserName = "admin@portal.com",
                }, adminPass).Result;

                if (result.Succeeded)
                {

                }
            }
        }
    }
}
