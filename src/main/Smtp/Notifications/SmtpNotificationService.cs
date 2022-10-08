using ei8.Net.Notifications;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ei8.Net.Email.Smtp.Notifications
{
    public class SmtpNotificationService : INotificationService<SmtpNotificationPayload, SmtpReceiver>
    {
        private readonly SmtpNotificationSettings settings;

        public SmtpNotificationService(SmtpNotificationSettings settings)
        {
            this.settings = settings;
        }

        public async Task SendAsync(SmtpNotificationPayload payload, SmtpReceiver receiver)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(this.settings.SenderName, this.settings.SenderAddress));
            message.To.Add(new MailboxAddress(receiver.Name, receiver.Address));
            message.Subject = payload.Subject;

            message.Body = new TextPart("plain")
            {
                Text = payload.Body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(settings.ServerAddress, settings.Port, settings.UseSsl);

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(this.settings.SenderUsername, this.settings.SenderPassword);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
