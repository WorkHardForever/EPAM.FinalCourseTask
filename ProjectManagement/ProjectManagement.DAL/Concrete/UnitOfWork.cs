using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.DAL.Interfacies.Interfacies;
using ProjectManagement.ORM;
using ProjectManagement.ORM.Entities;
using System.Data.Entity;

namespace ProjectManagement.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(EntityModel context)
        {
            Context = context;
        }

        public EntityModel Context { get; private set; }

        public void Commit()
        {
            Context?.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        /*
         private readonly WebDbContext _context;
        private readonly IDbTransaction _transaction;
        private readonly ObjectContext _objectContext;

        public UnitOfWork(IWebDbContext context)
        {
            this._context = context as WebDbContext ?? new WebDbContext();

            this._objectContext = ((IObjectContextAdapter)this._context).ObjectContext;

            if (this._objectContext.Connection.State != ConnectionState.Open)
            {
                this._objectContext.Connection.Open();
                this._transaction = _objectContext.Connection.BeginTransaction();
            }
        }

        public void Commit()
        {
            try
            {
                this._context.SaveChanges();
                this._transaction.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        private void Rollback()
        {
            this._transaction.Rollback();

            foreach (var entry in this._context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public void Dispose()
        {
            if (this._objectContext.Connection.State == ConnectionState.Open)
            {
                this._objectContext.Connection.Close();
            }
        }
         */
    }
}
