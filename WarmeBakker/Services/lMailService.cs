namespace WarmeBakker.Services
{
    public interface IMailService
    {
        void SendMail(object p, string email, string v, string message);
        void SendMessage(string to, string subject, string body);
    }
}