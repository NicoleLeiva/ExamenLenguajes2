using SoporteLab.Api.Data;
using SoporteLab.Api.Models;

namespace SoporteLab.Api.Services;

public class TicketService
{
    private readonly SoporteLabDbContext _context;

    public TicketService(SoporteLabDbContext context)
    {
        _context = context;
    }

    public List<Ticket> ObtenerTodos()
    {
        return _context.Tickets
            .OrderByDescending(t => t.FechaRegistro)
            .ToList();
    }

    public Ticket? ObtenerPorId(int id)
    {
        return _context.Tickets.FirstOrDefault(t => t.Id == id);
    }

    public Ticket Crear(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        _context.SaveChanges();
        return ticket;
    }
    public Ticket? Actualizar(int id, Ticket ticketActualizado)
    {
        var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);

        if (ticket == null)
            return null;

        ticket.Titulo = ticketActualizado.Titulo;
        ticket.Descripcion = ticketActualizado.Descripcion;
        ticket.Categoria = ticketActualizado.Categoria;
        ticket.Prioridad = ticketActualizado.Prioridad;
        ticket.Estado = ticketActualizado.Estado;
        ticket.Solicitante = ticketActualizado.Solicitante;

        _context.SaveChanges();

        return ticket;
    }

    public bool Eliminar(int id)
    {
        var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);

        if (ticket == null)
            return false;

        _context.Tickets.Remove(ticket);

        _context.SaveChanges();

        return true;
    }
}