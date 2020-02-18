using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace DAL
{
	public class IdentityDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager)
        {
			SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
			ApplicationUser user = userManager.FindByEmailAsync("superadmin@fm.com").Result;
			if (user == null)
			{
				user = new ApplicationUser()
				{
					LastName = "Admin",
					FirstName = "Super",
					Email = "superadmin@fm.com",
					UserName = "superadmin@fm.com"
				};

				var result = userManager.CreateAsync(user, "P@ssw0rd!").Result;
				if (result != IdentityResult.Success)
				{
					throw new InvalidOperationException("Could not create user while Seeding");
				}
			}
		}
	}
}
