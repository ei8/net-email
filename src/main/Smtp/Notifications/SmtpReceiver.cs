using ei8.Net.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ei8.Net.Email.Smtp.Notifications
{
    public class SmtpReceiver : INotificationReceiver
    {
        public string Address { get; set; }

        public string Name { get; set; }
    }
}
