using System;
using System.Data.Entity;

namespace ProjectManagement.DAL.Interface.Interfacies
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        void Commit();
    }
}
