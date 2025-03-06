using Microsoft.EntityFrameworkCore;
using EventosEnLineaVariados.Models;

namespace EventosEnLineaVariados.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoEvento> TipoEventos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<CategoriaEvento> CategoriaEventos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<UbicacionBoleto> UbicacionBoletos { get; set; }
    }
}
