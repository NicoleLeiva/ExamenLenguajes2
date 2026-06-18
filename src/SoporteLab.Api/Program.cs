using Microsoft.EntityFrameworkCore;
using SoporteLab.Api.Data;
using SoporteLab.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Servicios de la API
builder.Services.AddControllers();

// Swagger para probar/documentar la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de SQLite con EF Core
builder.Services.AddDbContext<SoporteLabDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
 builder.Services.AddScoped<TicketService>();
var app = builder.Build();

// Crear/aplicar migraciones automáticamente al iniciar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SoporteLabDbContext>();
   db.Database.EnsureCreated();

}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();