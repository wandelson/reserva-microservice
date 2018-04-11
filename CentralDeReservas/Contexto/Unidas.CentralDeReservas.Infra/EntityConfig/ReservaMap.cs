using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Unidas.CentralDeReservas.Dominio.Reservas.Entities;

namespace Unidas.CentralDeReservas.Infra.EntityConfig
{
    public class ReservaMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("RESTAB");
            builder.HasKey(a => new { RESNUM = a.Numero, RESLOJOPE = a.LojaOperacao }).HasName("SYS_C00455699");
            builder.Property(a => a.Numero).HasColumnName("RESNUM");
            builder.Property(a => a.LojaOperacao).HasColumnName("RESLOJOPE");
            builder.Property(x => x.Id).HasColumnName("ROWID");
            builder.Property(x => x.AtendimentoExpressoCliente).HasColumnName("RESEXPCLI");
           
            //    builder.OwnsOne<Condutor>(s => s.Condutor, cb => cb.Property(x => x.Nome).HasColumnName("RESCON"));

            builder.Ignore(x => x.Condutor);

        
        }

    }
}
