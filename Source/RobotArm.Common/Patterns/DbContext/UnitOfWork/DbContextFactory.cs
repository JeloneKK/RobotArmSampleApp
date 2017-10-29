using System;
using System.Collections.Generic;
using RobotArm.Common.Patterns.Disposing;

namespace RobotArm.Common.Patterns.DbContext.UnitOfWork
{
    public class DbContextFactory : Disposable, IDbContextFactory
    {
        private readonly Dictionary<Type, System.Data.Entity.DbContext> _dbContexts;

        public DbContextFactory()
        {
            _dbContexts = new Dictionary<Type, System.Data.Entity.DbContext>();
        }

        public T GetDbContext<T>() where T : System.Data.Entity.DbContext, new()
        {
            if (!_dbContexts.ContainsKey(typeof(T)))
            {
                _dbContexts.Add(typeof(T), new T());
            }

            return _dbContexts[typeof(T)] as T;
        }

        protected override void DisposeCore()
        {
            foreach (var kvpDbContext in _dbContexts)
            {
                kvpDbContext.Value?.Dispose();
            }
        }
    }
}