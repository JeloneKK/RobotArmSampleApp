using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using RobotArm.Common.Patterns.DbContext;
using RobotArm.Common.Patterns.DbContext.DbContextScope.Interfaces;
using RobotArm.Common.Patterns.DbContext.UnitOfWork;
using RobotArm.Data.Entities.UserManagement;
using RobotArm.RepositoriesInterfaces.UserManagement;

namespace RobotArm.UserManagementRepositories.RoleRepositories
{
    public class RoleRepository : UserManagementRepositoryBase<IdentityRole>, IRoleRepository
    {
        public RoleRepository(IAmbientDbContextLocator ambientDbContextLocator) 
            : base(ambientDbContextLocator)
        {
        }
    }
}