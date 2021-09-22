using System.Globalization;

namespace SteGriff.Web
{
    public static class AppExtensions
    {
        public static void UseHelloService(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<IHelloService, HelloService>();
        }

        public static void UseHelloRoutes(this WebApplication app)
        {
            app.MapGet("/hello", (IHelloService helloSvc, HttpContext httpContext) =>
                helloSvc.GetHello(httpContext)
            );
        }
    }
}
