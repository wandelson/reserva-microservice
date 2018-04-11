using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Unidas.Core.Entities;
using Unidas.CentralDeReservas.Infra.EntityConfig;
using Unidas.CentralDeReservas.Dominio.Reservas.Entities;

namespace Unidas.CentralDeReservas.Infra.Contexts
{
    public class ReservaContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReservaMap());

            base.OnModelCreating(modelBuilder);
        }

        public ReservaContext(DbContextOptions<ReservaContext> options) : base(options) { }

        public DbSet<Reserva> Reservas { get; set; }

    }
}
