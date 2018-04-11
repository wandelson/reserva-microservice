using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unidas.CentralDeReservas.Aplicacao.Reservas.QuerySide.Result
{
    public class ListarReservaResult
    {

        public decimal NumeroReserva { get; set; }
        public string LojaOperacao { get; set; }        
    }
}
