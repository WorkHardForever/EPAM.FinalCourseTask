using System.Threading.Tasks;

namespace ProjectManagement.BLL.Interface.Interfacies.Services
{
    public interface IMessageService
    {
        void SendEmail(string email, string subject, string message);
    }
}
