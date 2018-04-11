
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Unidas.CentralDeReservas.Aplicacao.Reservas.Commands;
using Unidas.CentralDeReservas.Aplicacao.Reservas.QuerySide.Query;

namespace Unidas.Servicos.Controllers
{
    [AllowAnonymous]
    public class ReservaController : BaseController
    {
        private readonly IMediator mediator;


        public ReservaController(IMediator mediator)
        {            
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("/api/v1/reservas")]
        public async Task<ResponseBase> Post([FromBody] CriarReservaCommand command)
        {
            var response = await mediator.Send(command);

            return await CreateCreatedResponse("Reserva crida.", response);
        }

        [HttpGet]
        [Route("/api/v1/reservas")]
        public async Task<ResponseBase> Get()
        {
            var response = await mediator.Send(new ListarReservaQuery());
          
            return await CreateOkResponse(response);
        }



        [HttpGet]
        [Route("/api/v1/ping")]
        public async Task<ResponseBase> Ping()
        {
            return await CreateOkResponse("PING!!");
        }

    }
}