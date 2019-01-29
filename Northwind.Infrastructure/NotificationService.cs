using Northwind.Application.Interfaces;
using Northwind.Application.Notifications.Models;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Northwind.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            var fromAddress = new MailAddress(message.From, "Notification");
            var toAddress = new MailAddress(message.To, "User");
            const string fromPassword = message.Password;
            const string subject = message.Subject;
            const string body = message.Body;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

            return Task.CompletedTask;
        }
    }
}
