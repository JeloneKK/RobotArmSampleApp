using System;

namespace RobotArm.Common.Patterns.DbContext.UnitOfWork
{
    public interface IDbContextFactory : IDisposable
    {
        T GetDbContext<T>() where T : System.Data.Entity.DbContext, new();
    }
}