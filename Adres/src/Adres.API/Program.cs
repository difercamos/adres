using Microsoft.EntityFrameworkCore;
using Adres.Infrastructure.Persistence;
using Adres.Application.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Prueba",
        Version = "v1",
        Description = "Documentación generada con Swagger"
    });
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var dbPath = Path.Combine(Directory.GetParent(builder.Environment.ContentRootPath)!.FullName, "adres.db");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddScoped<IAdquisicionService, AdquisicionService>();
builder.Services.AddScoped<IHistorialAdquisicionService, HistorialAdquisicionService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<ITipoBienServicioService, TipoBienServicioService>();
builder.Services.AddScoped<IUnidadAdministrativaService, UnidadAdministrativaService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Prueba v1");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();
app.MapControllers();
app.MapOpenApi();
app.UseHttpsRedirection();
app.Run();
