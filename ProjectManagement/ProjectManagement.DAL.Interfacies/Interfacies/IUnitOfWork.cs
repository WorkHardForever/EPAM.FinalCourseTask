using System;

namespace ProjectManagement.DAL.Interfacies.Interfacies
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
