using System.Net.Http.Json;

namespace SoporteLab.Web.Services;

public class TicketApiService
{
    private readonly HttpClient _http;

    public TicketApiService(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient("SoporteLabApi");
    }

    public async Task<List<TicketDto>> ObtenerTicketsAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<TicketDto>>("api/tickets") ?? new();
        }
        catch
        {
            return new();
        }
    }

    public async Task CrearTicketAsync(TicketDto ticket)
    {
        await _http.PostAsJsonAsync("api/tickets", ticket);
    }

    public async Task ActualizarTicketAsync(TicketDto ticket)
    {
        await _http.PutAsJsonAsync($"api/tickets/{ticket.Id}", ticket);
    }

    public async Task EliminarTicketAsync(int id)
    {
        await _http.DeleteAsync($"api/tickets/{id}");
    }
}

public class TicketDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public string Categoria { get; set; } = "";
    public string Prioridad { get; set; } = "";
    public string Estado { get; set; } = "";
    public string Solicitante { get; set; } = "";
    public DateTime FechaRegistro { get; set; }
}