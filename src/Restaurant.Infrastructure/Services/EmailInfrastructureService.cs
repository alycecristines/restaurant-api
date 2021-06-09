using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Configuration;
using Restaurant.Domain.Interfaces;
using Restaurant.Infrastructure.Options;

namespace Restaurant.Infrastructure.Services
{
    public class EmailInfrastructureService : IEmailDomainService
    {
        private Encoding _encoding => Encoding.UTF8;
        private readonly SmtpOptions _smtpOptions;

        public EmailInfrastructureService(IConfiguration configuration)
        {
            _smtpOptions = new SmtpOptions();
            configuration.GetSection(SmtpOptions.SectionName).Bind(_smtpOptions);
        }

        public void Send(string to, string subject, string message)
        {
            CreateSmtpClient().Send(CreateMailMessage(to, subject, message));
        }

        private SmtpClient CreateSmtpClient()
        {
            var smtpClient = new SmtpClient();
            smtpClient.Host = _smtpOptions.Host;
            smtpClient.Port = _smtpOptions.Port;
            smtpClient.UseDefaultCredentials = _smtpOptions.UseDefaultCredentials;
            smtpClient.Credentials = CreateNetworkCredential();
            smtpClient.EnableSsl = _smtpOptions.EnableSSL;
            return smtpClient;
        }

        private NetworkCredential CreateNetworkCredential()
        {
            return new NetworkCredential(
                _smtpOptions.Email,
                _smtpOptions.Password
            );
        }

        private MailMessage CreateMailMessage(string to, string subject, string message)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(to);
            mailMessage.From = CreateFromMailAddress();
            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = _encoding;
            mailMessage.Body = message;
            mailMessage.BodyEncoding = _encoding;
            mailMessage.IsBodyHtml = false;
            mailMessage.Priority = MailPriority.High;
            return mailMessage;
        }

        private MailAddress CreateFromMailAddress()
        {
            return new MailAddress(
                _smtpOptions.Email,
                _smtpOptions.DisplayName,
                _encoding
            );
        }
    }
}
