using ProjectManagement.ORM;
using System;

namespace ProjectManagement.DAL.Interface.Interfacies
{
    public interface IUnitOfWork : IDisposable
    {
        EntityModel Context { get; }

        void Commit();
    }
}
