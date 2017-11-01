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
            UserWithRoles[] usersWithRoles = {
                new UserWithRoles("Admin", new string[] { "Administrator" , "Distributor" },"somepassword"),//user and optional roles and password you want to seed 
                new UserWithRoles("PlainUser"),
                new UserWithRoles("Jojo",new string[]{"Distributor" }) //seed roles to existing users (e.g. facebook login).
            };

            foreach (var userWithRoles in usersWithRoles)
            {
                foreach (string role in userWithRoles.Roles)
                {
                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        context.Roles.AddOrUpdate(new IdentityRole(role));
                    }
                }

                context.Users.AddOrUpdate(userWithRoles.User);
            }

            context.SaveChangesAsync();
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
                    NormalizedEmail = name.ToUpper() + "@GMAIL.COM",
                    UserName = name,
                    NormalizedUserName = name.ToUpper(),
                    PhoneNumber = "+1312341234",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = new PasswordHasher().HashPassword(password),
                };
            }
        }
    }
}