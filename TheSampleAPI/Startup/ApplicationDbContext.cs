using System.Runtime.CompilerServices;
using TheSampleAPI.Data;

namespace TheSampleAPI.Startup
{
    public static class ApplicationDbContext
    {
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenApiServices();
            builder.Services.AddCorsServices();
        
            builder.Services.AddAllHealthChecks();
            builder.Services.AddTransient<CourseData>();
        }
    }
}
