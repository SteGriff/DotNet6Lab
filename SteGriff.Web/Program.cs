using SteGriff.Data;
using SteGriff.Web;

var builder = WebApplication.CreateBuilder(args);
builder.UseHelloService();
builder.UseShipData();

var app = builder.Build();
app.UseHelloRoutes();
app.UseShipRoutes();

app.MapGet("/", () => "I'm alive");

app.Run();
