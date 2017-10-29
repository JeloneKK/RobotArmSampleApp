namespace RobotArm.Common.Patterns.DbContext.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork
        where T : System.Data.Entity.DbContext, new()
    {
        private readonly IDbContextFactory _dbContextFactory;
        private T _dbContext;

        public UnitOfWork(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public T DbContext => _dbContext ?? (_dbContext = _dbContextFactory.GetDbContext<T>());

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}