using ProjectManagement.DAL.Interfacies.Interfacies;
using System.Data.Entity;

namespace ProjectManagement.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get; private set; }

        public void Commit()
        {
            Context?.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
