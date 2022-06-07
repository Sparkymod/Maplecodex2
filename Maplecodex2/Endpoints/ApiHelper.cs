using System.Net.NetworkInformation;

namespace RDK.Endpoints
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApiHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        public static void MapApiHelpers(this WebApplication app)
        {
            app.MapGet("/api/v1/service/status", () => Results.Ok("Online"));
        }
    }
}
