using MediatR;
using System.Collections.Generic;
using Unidas.CentralDeReservas.Aplicacao.Reservas.QuerySide.Result;

namespace Unidas.CentralDeReservas.Aplicacao.Reservas.QuerySide.Query
{
    public class ListarReservaQuery : IRequest<IEnumerable<ListarReservaResult>>
    {
    }
}
