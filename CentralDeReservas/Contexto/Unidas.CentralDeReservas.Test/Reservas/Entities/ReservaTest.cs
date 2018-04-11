using System;
using Unidas.CentralDeReservas.Dominio.Reservas.Entities;
using Xunit;



namespace Unidas.CentralDeReservas.Test.Reservas.Entities
{
    public class ReservaTest
    {
        [Fact]
        public void Reserva_Validada_Com_Sucesso()
        {
            //Arrange:
            var condutor = new Condutor("João Pereira");
            var reserva = new Reserva(condutor, "SP");
            
            //Act:
             var nomeCondutor = reserva.Condutor;
            
            //Assert:
            Assert.Equal(nomeCondutor.Nome, condutor.Nome);
            Assert.NotEqual(0, reserva.Numero);

        }
    }
}
