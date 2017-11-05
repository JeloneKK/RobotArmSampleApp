using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.BusinessLogicInterfaces.UserManagement;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.RepositoriesInterfaces.UserManagement;

namespace RobotArm.UserManagementBusinessLogic.UserBusinessLogics
{
    public class UserBusinessLogic : UserManagementBusinessLogicBase, IUserBusinessLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserBusinessLogic(IDbContextScopeFactory dbContextScopeFactory, IUserRepository userRepository, IRoleRepository roleRepository) 
            : base(dbContextScopeFactory)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public ApplicationUser GetUser(string userId)
        {
            using (DbContextScopeFactory.CreateReadOnly())
            {
                var user = _userRepository.GetById(userId);

                if (user == null)
                {
                    throw new ArgumentException($"Couldn't find a user with ID: {userId}.");
                }

                return user;
            }
        }

        public List<ApplicationUser> GetAllUsers()
        {
            using (DbContextScopeFactory.CreateReadOnly())
            {
                var users = _userRepository.GetAll();

                return users.ToList();
            }
        }

        public List<IdentityRole> GetUserRoles(string userId)
        {
            using (DbContextScopeFactory.CreateReadOnly())
            {
                IEnumerable<string> rolesIds = this.GetUser(userId).Roles.Select(r => r.RoleId);

                IEnumerable<IdentityRole> identityRoles = _roleRepository.GetMany(r => rolesIds.Contains(r.Id));

                return identityRoles.ToList();
            }
        }

        public void CreateUser(ApplicationUser user)
        {
            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                _userRepository.Add(user);
                dbContextScope.SaveChanges();
            }
        }

        public void UpdateUser(ApplicationUser user)
        {
            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                _userRepository.Update(user);
                dbContextScope.SaveChanges();
            }
        }

        public void DeleteUser(string userId)
        {
            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                _userRepository.Delete(u => u.Id == userId);
                dbContextScope.SaveChanges();
            }
        }
    }
}