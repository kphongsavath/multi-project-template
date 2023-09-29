using System.Net.Mail;

namespace $ext_safeprojectname$.Integration.Interfaces
{
    public interface IEmailService
    {
        void SendAsync(string from, string recipients, string? subject, string? body);
        void SendAsync(Action<MailMessage> action);
        void SendEmail(Action<MailMessage> action);
    }
}
