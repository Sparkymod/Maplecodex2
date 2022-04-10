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
    }
}
