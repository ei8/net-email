using ei8.Net.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ei8.Net.Email.Smtp.Notifications
{
    public class SmtpNotificationPayload : INotificationPayload
    {
        public string Subject { get; set; }

        public Dictionary<string, object> Options { get; set; } = new Dictionary<string, object>();

        public string Body
        {
            get => GetOptionValueOrNull<string>(nameof(Body));
            set => AddOrUpdateOption(nameof(Body), value);
        }

        private T GetOptionValueOrNull<T>(string propName) where T : class
        {
            T value = null;

            if (Options != null)
            {
                object objectValue;
                Options.TryGetValue(propName.ToLower(), out objectValue);

                value = (T)objectValue;
            }

            return value;
        }

        private void AddOrUpdateOption(string propName, object value)
        {
            var actualPropName = propName.ToLower();

            if (Options?.ContainsKey(actualPropName) == true)
                Options[actualPropName] = value;

            else
                Options.Add(actualPropName, value);
        }
    }
}
