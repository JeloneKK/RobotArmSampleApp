using System.Linq;
using NUnit.Framework;
using RobotArm.Data.DbContexts.RobotArmControl;
using RobotArm.Data.DbContexts.UserManagement;
using RobotArm.Data.SeedData.RobotArmControl;
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
            using (UserManagementDbContext userDbContext = new UserManagementDbContext())
            {
                // Act
                var roles = userDbContext.Roles.Where(e => true);

                // Assert
                Assert.NotNull(roles);
            }
        }

        [Test]
        public void RobotArmControlDbContextCreated_AccessDate_DataIsReceived()
        {
            // Arrange
            System.Data.Entity.Database.SetInitializer(new RobotArmControlSeedData());

            using (RobotArmControlDbContext userDbContext = new RobotArmControlDbContext())
            {
                // Act
                var programs = userDbContext.RobotProgram.Where(e => true);

                // Assert
                Assert.NotNull(programs);
            }
        }
    }
}