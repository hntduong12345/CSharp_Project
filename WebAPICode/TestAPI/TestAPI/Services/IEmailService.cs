using TestAPI.Models;

namespace TestAPI.Services
{
    public interface IEmailService
    {
        void sendEmail(Message message);
    }
}
