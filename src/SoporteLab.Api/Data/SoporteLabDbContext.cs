using Microsoft.EntityFrameworkCore;
using SoporteLab.Api.Models;

namespace SoporteLab.Api.Data;

public class SoporteLabDbContext : DbContext
{
    public SoporteLabDbContext(
        DbContextOptions<SoporteLabDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets => Set<Ticket>();
}