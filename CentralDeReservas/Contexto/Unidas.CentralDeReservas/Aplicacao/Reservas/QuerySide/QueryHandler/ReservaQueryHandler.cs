using System.Threading.Tasks;
using Unidas.CentralDeReservas.Dominio.Reservas.Interfaces;
using MediatR;
using Unidas.CentralDeReservas.Aplicacao.Reservas.QuerySide.Query;
using Unidas.CentralDeReservas.Aplicacao.Reservas.QuerySide.Result;
using System.Collections.Generic;

namespace Unidas.CentralDeReservas.QuerySide.QueryHandler
{
    public class ReservaQueryHandler : AsyncRequestHandler<ListarReservaQuery, IEnumerable<ListarReservaResult>>
    {
        private readonly IReservaRepository repository;


        public ReservaQueryHandler(IReservaRepository repository)
        {
            this.repository = repository;
        }
     


        protected override Task<IEnumerable<ListarReservaResult>> HandleCore(ListarReservaQuery request)
        {
            return  repository.Listar();
        }

    }
}