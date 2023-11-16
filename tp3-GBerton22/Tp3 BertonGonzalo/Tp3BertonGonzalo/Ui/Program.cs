using Tp3BertonGonzalo.Controllers;
using Tp3BertonGonzalo.Services;
var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<LibroServices>();
builder.Services.AddSingleton<PrestamosServices>();
builder.Services.AddSingleton<InformeServices>();
builder.Services.AddScoped<InformeServices>();

var app = builder.Build();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();