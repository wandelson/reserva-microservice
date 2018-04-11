using System.Threading.Tasks;
using Unidas.CentralDeReservas.Aplicacao.Reservas.Commands;
using Unidas.CentralDeReservas.Aplicacao.Reservas.Result;
using Unidas.CentralDeReservas.Dominio.Reservas.Interfaces;
using Unidas.CentralDeReservas.Dominio.Reservas.Entities;
using System;
using MediatR;

namespace Unidas.CentralDeReservas.Services
{
    public class ReservaCommandHandler : AsyncRequestHandler<CriarReservaCommand, CriarReservaResult>
    {
        private readonly IReservaRepository repository;
        private readonly IUnitOfWork unitOfWork;


        public ReservaCommandHandler(IReservaRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }


        protected override Task<CriarReservaResult> HandleCore(CriarReservaCommand command)
        {        
            var condutor = new Condutor(command.NomeCondutor);

            var reserva = new Reserva(condutor, "SP");
            reserva.DefinirAtendimento(Reserva.AtendimentoExpressoClienteRealizado);
            reserva.DefinirNumeroReserva();

            repository.Salvar(reserva);

            unitOfWork.Commit();

            var result = new CriarReservaResult
            {
                NumeroReserva = reserva.Numero
            };

            return Task.FromResult(result);
        }
    }
}