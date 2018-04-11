

using System.Collections.Generic;
using System.Threading.Tasks;
using Unidas.CentralDeReservas.Aplicacao.Reservas.QuerySide.Result;
using Unidas.CentralDeReservas.Dominio.Reservas.Entities;

namespace Unidas.CentralDeReservas.Dominio.Reservas.Interfaces
{
    public interface IReservaRepository
    {
        Task Salvar(Reserva reserva);

        Task<IEnumerable<ListarReservaResult>> Listar();
    }
}