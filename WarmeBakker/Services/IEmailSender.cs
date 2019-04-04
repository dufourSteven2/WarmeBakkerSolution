using System.Threading.Tasks;

namespace WarmeBakker.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}