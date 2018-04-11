using NSubstitute;
using System;
using Unidas.CentralDeReservas.Aplicacao.Reservas.Commands;
using Unidas.CentralDeReservas.Aplicacao.Reservas.Result;
using Unidas.CentralDeReservas.Aplicacao.Reservas.Validators;
using Unidas.CentralDeReservas.Dominio.Reservas.Interfaces;
using Unidas.CentralDeReservas.Dominio.Reservas.Entities;
using Xunit;



namespace Unidas.CentralDeReservas.Test.Services
{
    public class ReservaServiceTest
    {        
        private readonly IReservaRepository mock;

        public ReservaServiceTest()
        {
            mock = Substitute.For<IReservaRepository>();
        }

        [Fact]
        public async void  Reserva_Criada_Com_Sucessso()
        {
            //Arrange:            
            var command = new CriarReservaCommand
            {
                Acordo = 1,
                CanalVenda = 2,
                NomeCondutor = "wans",
                Tarifa = 2
            };

            //Act            
            var valido = new CriarReservaCommandValidator().Validate(command).IsValid;
            var condutor = new Condutor(command.NomeCondutor);
            var reserva = new Reserva(condutor, "SP");
            if(valido) await mock.Salvar(reserva);
                      
            //Assert:           
            Assert.True(valido);

        }

    }
}
