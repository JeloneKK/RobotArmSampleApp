using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.Data.DbContexts.UserManagement;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.Data.SeedData.UserManagement
{
    public class UserManagementSeedData : CreateDatabaseIfNotExists<UserManagementDbContext>
    {
        protected override void Seed(UserManagementDbContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }

        public static void InitializeIdentityForEf(UserManagementDbContext db)
        {
            AddRoles(new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db)));

            if (!db.Users.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);

                // Add missing roles
                var role = roleManager.FindByName("Admin");
                if (role == null)
                {
                    role = new IdentityRole("Admin");
                    roleManager.Create(role);
                }

                // Create test users
                var user = userManager.FindByName("Admin");
                if (user == null)
                {
                    var newUser = new ApplicationUser()
                    {
                        UserName = "admin",
                        FirstName = "Admin",
                        LastName = "User",
                        Email = "xxx@xxx.net",
                        PhoneNumber = "5551234567"
                    };
                    userManager.Create(newUser, "Password1");
                    userManager.SetLockoutEnabled(newUser.Id, false);
                    userManager.AddToRole(newUser.Id, "Admin");
                }
            }
        }

        private static void AddRoles(RoleManager<IdentityRole> roleManager)
        {
            var roles = GetRoles();

            foreach (var role in roles)
            {
                roleManager.Create(new IdentityRole(role));
            }
        }

        private static List<string> GetRoles()
        {
            return new List<string>
            {
                "Admin",
                "Engineer",
                "Custom"
            };
        }

        private class UserWithRoles
        {
            public ApplicationUser User { get; }

            public string[] Roles { get; private set; }

            public UserWithRoles(string name, string[] roles = null, string password = "secret")
            {
                Roles = roles ?? new string[] { };
                User = new ApplicationUser
                {
                    Email = name + "@gmail.com",
                    UserName = name,
                    PhoneNumber = "+1312341234",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = new PasswordHasher().HashPassword(password)
                };
            }
        }
    }
}