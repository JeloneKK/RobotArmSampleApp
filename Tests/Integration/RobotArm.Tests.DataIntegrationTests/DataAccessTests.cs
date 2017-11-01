using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RobotArm.Data.DbContexts.UserManagement;
using RobotArm.Data.SeedData.UserManagement;

namespace RobotArm.Tests.DataIntegrationTests
{
    [TestFixture]
    public class DataAccessTests
    {
        [Test]
        public void UserDbContextCreated_AccessDate_DataIsReceived()
        {
            // Arrange
            using (UserManagementDbContext userDbContext = new UserManagementDbContext(new DbContextOptions<UserManagementDbContext>()))
            {
                // Act
                var roles = userDbContext.Roles.Where(e => true);

                // Assert
                Assert.NotNull(roles);
            }
        }
    }
}