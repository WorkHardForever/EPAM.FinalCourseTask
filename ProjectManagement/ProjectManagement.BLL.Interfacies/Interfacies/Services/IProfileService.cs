using ProjectManagement.BLL.Interface.Entities;
using System.Collections.Generic;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface IProfileService
    {
        void Create(BllProfile profile);

        BllProfile GetById(int uniqueId);

        BllProfile GetByEmail(string email);
    }
}
