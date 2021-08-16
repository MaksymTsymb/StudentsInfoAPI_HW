using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BusinessLayer.Services
{
    public class MailExchangerService : IMailExchangerService
    {
        private readonly SmtpOptions smtpOptions;

        public MailExchangerService(IOptions<SmtpOptions> smtpOptions)
        {
            this.smtpOptions = smtpOptions.Value;
        }

        public void SendMessage(string destMail, string messageSubject, string messageBody)
        {
            var from = new MailAddress(smtpOptions.SenderMail, smtpOptions.SenderName);
            using var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpOptions.SenderMail,
                      smtpOptions.SenderPassword)
            };
            var to = new MailAddress(destMail);
            var message = new MailMessage(from, to)
            {
                Body = messageBody,
                Subject = messageSubject
            };

            client.Send(message);
        }
    }
}