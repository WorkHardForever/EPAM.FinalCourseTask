using ProjectManagement.ORM;
using System;

namespace ProjectManagement.DAL.Interfacies.Interfacies
{
    public interface IUnitOfWork : IDisposable
    {
        EntityModel Context { get; }

        void Commit();
    }
}
