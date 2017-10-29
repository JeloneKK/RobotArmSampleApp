using System;
using System.Collections.Generic;
using System.Linq;
using RobotArm.BusinessLogicInterfaces.UserManagement;
using RobotArm.Common.Patterns.DbContext;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Common.Patterns.DbContext.UnitOfWork;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.RepositoriesInterfaces.UserManagement;

namespace RobotArm.UserManagementBusinessLogic.UserBusinessLogics
{
    public class UserBusinessLogic : UserManagementBusinessLogicBase, IUserBusinessLogic
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        public UserBusinessLogic(IDbContextScopeFactory dbContextScopeFactory, IUserRepository userRepository, IRoleRepository roleRepository) 
            : base(dbContextScopeFactory)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public User GetUser(int userId)
        {
            using (_dbContextScopeFactory.CreateReadOnly())
            {
                var user = _userRepository.GetById(userId);

                if (user == null)
                {
                    throw new ArgumentException($"Couldn't find a user with ID: {userId}.");
                }

                return user;
            }
        }

        public List<Role> GetUserRoles(int userId)
        {
            using (_dbContextScopeFactory.CreateReadOnly())
            {
                User user = this.GetUser(userId);

                return user.Roles.ToList();
            }
        }

        public void CreateUser(User user)
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _userRepository.Add(user);
                dbContextScope.SaveChanges();
            }
        }
    }
}