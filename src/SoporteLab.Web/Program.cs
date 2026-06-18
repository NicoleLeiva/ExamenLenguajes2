using SoporteLab.Web.Components;
using SoporteLab.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Cliente HTTP para comunicarse con SoporteLab.Api
builder.Services.AddHttpClient("SoporteLabApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5136/");
});

// Registrar nuestro servicio de tickets
builder.Services.AddScoped<TicketApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();