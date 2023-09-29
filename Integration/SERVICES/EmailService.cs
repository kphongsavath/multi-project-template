using Microsoft.Extensions.Logging;
using System.Net.Mail;
using $ext_safeprojectname$.Common.Configurations;
using $ext_safeprojectname$.Integration.Interfaces;

namespace $ext_safeprojectname$.Integration.Services
{
    internal class EmailService : ServiceBase<IEmailService>, IEmailService
    {
        public EmailService(AppSettings appSettings, ILogger<IEmailService> logger) : base(appSettings, logger)
        {
        }
        public void SendAsync(string from, string recipients, string? subject, string? body)
        {
            SendAsync((msg) =>
             {
                 _logger.LogInformation($"Sending Email Notification");
                 if (!string.IsNullOrEmpty(from))
                 {
                     msg.From = new MailAddress(from);
                 }
                 if (!string.IsNullOrEmpty(body))
                 {
                     msg.Body = body;
                 }
                 if (!string.IsNullOrEmpty(recipients))
                 {
                     msg.To.Add(recipients);
                 }
                 if (!string.IsNullOrEmpty(subject))
                 {
                     msg.Subject = subject;
                 }
             });

        }
        public void SendAsync(Action<MailMessage> action)
        {
            if (action != null)
            {
                using var msg = new MailMessage(_appSettings.SmtpSettings.From,
                    _appSettings.SmtpSettings.To,
                    _appSettings.SmtpSettings.Subject,
                    string.Empty);
                if (!string.IsNullOrEmpty(_appSettings.SmtpSettings.Cc))
                {
                    msg.CC.Add(_appSettings.SmtpSettings.Cc);
                }

                action.Invoke(msg);
                using var client = new SmtpClient(_appSettings.SmtpSettings.Host, _appSettings.SmtpSettings.Port)
                {
                    EnableSsl = _appSettings.SmtpSettings.EnableSsl,
                    UseDefaultCredentials = _appSettings.SmtpSettings.UseDefaultCredentials,

                };
                client.SendAsync(msg,null);
            }
        }
        public void SendEmail(Action<MailMessage> action)
        {
            if (action != null)
            {
                using var msg = new MailMessage(_appSettings.SmtpSettings.From,
                    _appSettings.SmtpSettings.To,
                    _appSettings.SmtpSettings.Subject,
                    string.Empty);
                if (!string.IsNullOrEmpty(_appSettings.SmtpSettings.Cc))
                {
                    msg.CC.Add(_appSettings.SmtpSettings.Cc);
                }

                action.Invoke(msg);
                using var client = new SmtpClient(_appSettings.SmtpSettings.Host, _appSettings.SmtpSettings.Port)
                {
                    EnableSsl = _appSettings.SmtpSettings.EnableSsl,
                    UseDefaultCredentials = _appSettings.SmtpSettings.UseDefaultCredentials,

                };
                client.Send(msg);
            }

        }
    }
}
