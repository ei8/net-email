using System;
using System.Collections.Generic;
using System.Text;

namespace ei8.Net.Email.Smtp.Notifications
{
    public class SmtpNotificationSettings
    {
        public string ServerAddress { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string SenderUsername { get; set; }
        public string SenderPassword { get; set; }
    }
}
