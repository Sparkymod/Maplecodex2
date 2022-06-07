using RDK.Endpoints;

namespace RDK.Data.Extensions
{
    public static class WebAppExtensions
    {
        public static void MapEndpoints(this WebApplication app)
        {
            // Mappings
            app.MapApiHelpers();
        }
    }
}
