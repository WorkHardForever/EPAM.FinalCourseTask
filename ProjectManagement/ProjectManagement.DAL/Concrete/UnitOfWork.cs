using ProjectManagement.DAL.Interfacies.Interfacies;
using ProjectManagement.ORM;
using System;

namespace ProjectManagement.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public EntityModel Context { get; private set; }

        public UnitOfWork(EntityModel context)
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
                throw new Exception("Database not save data", ex);
            }
        }

        public void Dispose()
        {
            if (Context == null)
                throw new NullReferenceException(nameof(Context));

            Context.Dispose();
        }
    }
}
