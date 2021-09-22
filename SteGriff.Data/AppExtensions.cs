using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SteGriff.Data
{
    public static class AppExtensions
    {
        public static void UseShipData(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddDbContext<ShipContext>(o => o.UseInMemoryDatabase("Ships"));
        }

        public static void UseShipRoutes(this WebApplication app)
        {
            app.MapGet("/ships", (ShipContext context) =>
            {
                return context.Ships.ToList();
            });

            app.MapGet("/ship/{code}", (ShipContext context, string code) =>
            {
                return context.Ships.FirstOrDefault(s => s.Code == code);
            });

            app.MapPost("/ship", (ShipContext context, Ship s) =>
            {
                context.Add(s);
                context.SaveChanges();
                return Results.Created($"/ship/{s.Code}", s);
            });
        }
    }
}
