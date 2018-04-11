using Unidas.CentralDeReservas.Dominio.Reservas.Interfaces;
using Unidas.CentralDeReservas.Infra.Contexts;

namespace Unidas.CentralDeReservas.Infra.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReservaContext _context;

        public UnitOfWork(ReservaContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Rollback()
        {
            // Do Nothing
        }
    }
}
