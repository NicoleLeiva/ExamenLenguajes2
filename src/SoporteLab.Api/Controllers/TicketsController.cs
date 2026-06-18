using Microsoft.AspNetCore.Mvc;
using SoporteLab.Api.Models;
using SoporteLab.Api.Services;

namespace SoporteLab.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly TicketService _servicio;

    public TicketsController(TicketService servicio)
    {
        _servicio = servicio;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Ticket>> ObtenerTodos()
    {
        return Ok(_servicio.ObtenerTodos());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Ticket> ObtenerPorId(int id)
    {
        var ticket = _servicio.ObtenerPorId(id);

        if (ticket is null)
            return NotFound(new { mensaje = $"Ticket con Id {id} no encontrado." });

        return Ok(ticket);
    }

    [HttpPost]
    public ActionResult<Ticket> Crear([FromBody] CrearTicketRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Titulo))
            return BadRequest(new { mensaje = "El título no puede estar vacío." });

        if (string.IsNullOrWhiteSpace(request.Solicitante))
            return BadRequest(new { mensaje = "El solicitante no puede estar vacío." });

        var prioridadesPermitidas = new[] { "Baja", "Media", "Alta", "Crítica" };
        var categoriasPermitidas = new[] { "Hardware", "Software", "Red", "Acceso", "Otro" };

        if (!prioridadesPermitidas.Contains(request.Prioridad))
            return BadRequest(new { mensaje = "La prioridad no es válida." });

        if (!categoriasPermitidas.Contains(request.Categoria))
            return BadRequest(new { mensaje = "La categoría no es válida." });

        var ticket = new Ticket
        {
            Titulo = request.Titulo.Trim(),
            Descripcion = request.Descripcion.Trim(),
            Categoria = request.Categoria.Trim(),
            Prioridad = request.Prioridad.Trim(),
            Estado = "Abierto",
            Solicitante = request.Solicitante.Trim(),
            FechaRegistro = DateTime.Now
        };

        _servicio.Crear(ticket);

        return CreatedAtAction(nameof(ObtenerPorId), new { id = ticket.Id }, ticket);
    }
    [HttpPut("{id:int}")]
    public ActionResult<Ticket> Actualizar(int id, [FromBody] Ticket ticket)
    {
        var actualizado = _servicio.Actualizar(id, ticket);

        if (actualizado == null)
            return NotFound();

        return Ok(actualizado);
    }


    [HttpDelete("{id:int}")]
    public IActionResult Eliminar(int id)
    {
        var eliminado = _servicio.Eliminar(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}


public record CrearTicketRequest(
    string Titulo,
    string Descripcion,
    string Categoria,
    string Prioridad,
    string Solicitante
);