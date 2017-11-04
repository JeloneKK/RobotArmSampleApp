using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.BusinessLogicInterfaces.UserManagement;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.CommonBusinessLogic;
using RobotArm.RepositoriesInterfaces.UserManagement;

namespace RobotArm.UserManagementBusinessLogic.RoleBusinessLogics
{
    public class UserRolesBusinessLogic : UserManagementBusinessLogicBase, IUserRolesBusinessLogic
    {
        private readonly IRoleRepository _roleRepository;
        private IUserRepository _userRepository;

        public UserRolesBusinessLogic(IDbContextScopeFactory dbContextScopeFactory, IRoleRepository roleRepository, IUserRepository userRepository)
            : base(dbContextScopeFactory)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public List<IdentityRole> GetAllRoles()
        {
            using (DbContextScopeFactory.CreateReadOnly())
            {
                var roles = _roleRepository.GetAll().ToList();

                return roles;
            }
        }

        public IdentityRole GetRole(string roleId)
        {
            using (DbContextScopeFactory.CreateReadOnly())
            {
                var role = _roleRepository.GetById(roleId);

                if (role == null)
                {
                    throw new ArgumentException($"Couldn't find a role with ID: {roleId}.");
                }

                return role;
            }
        }
    }
}