using System.Threading.Tasks;

namespace Alamut.Service.Messaging.Contracts
{
    public interface ISmsService
    {
        Task SendSmsAsync(string number, string message);
    }
}
