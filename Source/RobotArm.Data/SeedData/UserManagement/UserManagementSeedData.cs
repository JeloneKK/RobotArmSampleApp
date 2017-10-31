using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using RobotArm.Data.DbContexts.UserManagement;
using RobotArm.Data.Entities.UserManagement;

namespace RobotArm.Data.SeedData.UserManagement
{
    public class UserManagementSeedData : DropCreateDatabaseIfModelChanges<UserManagementDbContext>
    {
        protected override void Seed(UserManagementDbContext context)
        {
            Role[] roles = GetRoles().ToArray();
            context.Roles.AddOrUpdate(r => r.RoleId, roles);
            context.Users.AddOrUpdate(u => u.UserId, GetUsers(roles).ToArray());

            context.SaveChanges();
        }

        private static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    RoleId = 1,
                    Name = "GLOBAL_ADMINISTRATOR"
                },
                new Role
                {
                    RoleId = 2,
                    Name = "OPERATOR"
                },
                new Role
                {
                    RoleId = 3,
                    Name = "ANONYMOUS"
                },
                new Role
                {
                    RoleId = 5,
                    Name = "BNF"
                }
            };
        }

        private static List<User> GetUsers(Role[] roles)
        {
            return new List<User>
            {
                new User
                {
                    UserId = 1,
                    Login = "JKowalski",
                    HashPassword = "ABCD",
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Roles = new List<Role>
                    {
                        roles.Single(r => r.RoleId == 1)
                    }
                },
                new User
                {
                    UserId = 2,
                    Login = "ANowak",
                    HashPassword = "VBNM",
                    FirstName = "Andrzej",
                    LastName = "Nowak",
                    Roles = new List<Role>
                    {
                        roles.Single(r => r.RoleId == 2)
                    }
                }
            };
        }
    }
}