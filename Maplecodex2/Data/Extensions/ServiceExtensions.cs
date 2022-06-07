using Maplecodex2.Components.Notification;
using System.Reflection;

namespace Maplecodex2.Data.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddAllServicesAvailable(this IServiceCollection services, string @namespace = "Maplecodex2.Data.Services")
        {
            List<Type> serviceClassList = Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsAbstract && t.IsClass && t.Namespace == @namespace && t.Name.EndsWith("Service")).ToList();
            foreach (Type service in serviceClassList)
            {
                services.AddTransient(service);
            }
        }

        /// <summary>
        /// Inject RDK Notification system as a Service.
        /// </summary>
        public static void AddRDKNotification(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
