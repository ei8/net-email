using ei8.Net.Email.Smtp.Notifications;
using ei8.Net.Notifications;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ei8.Net.Email
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationService<SmtpNotificationPayload, SmtpReceiver>, SmtpNotificationService>();
            return services;
        }
    }
}
