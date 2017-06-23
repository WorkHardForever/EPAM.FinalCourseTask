using ProjectManagement.DAL.Interface.Interfacies;
using System;
using System.Data.Entity;

namespace ProjectManagement.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            if (Context == null)
                throw new NullReferenceException(nameof(Context));

            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Database don't save the data", ex);
            }
        }

        public void Dispose()
        {
            if (Context == null)
                throw new NullReferenceException(nameof(Context));

            Context.Dispose();
            Context = null;
        }
    }
}
