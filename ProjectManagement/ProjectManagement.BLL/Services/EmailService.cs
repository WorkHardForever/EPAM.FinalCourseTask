using MimeKit;
using MailKit.Net.Smtp;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using System;

namespace ProjectManagement.BLL.Services
{
    public class EmailService : IMessageService
    {
        private static readonly string senderEmail = "men.epam@yandex.ru";
        private static readonly string senderPassword = "qwerty123456";
        private static readonly string senderName = "localhost:port";
        private static readonly string senderHost = "smtp.yandex.ru";
        private static readonly int senderPort = 25;

        public void SendEmail(string email, string subject, string message)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException(nameof(email));

            if (string.IsNullOrEmpty(subject))
                throw new ArgumentException(nameof(subject));

            if (string.IsNullOrEmpty(message))
                throw new ArgumentException(nameof(message));

            Send(email, subject, message);
        }

        private void Send(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(senderName, senderEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.Connect(senderHost, senderPort, false);
                client.Authenticate(senderEmail, senderPassword);
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
