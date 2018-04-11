using MediatR;
using Unidas.CentralDeReservas.Aplicacao.Reservas.Result;

namespace Unidas.CentralDeReservas.Aplicacao.Reservas.Commands
{

    
    public class CriarReservaCommand : IRequest<CriarReservaResult>
    {
        public int CanalVenda { get; set; }
        public int Acordo { get; set; }
        public int Tarifa { get; set; }
        public string NomeCondutor { get; set; }
    }

  
}