using System;
using Unidas.Core.Entities;

namespace Unidas.CentralDeReservas.Dominio.Reservas.Entities
{

    

    public class Reserva : Entity
    {



        public Reserva()
        {

        }

        public virtual Condutor Condutor { get; private set; }

        public virtual Decimal Numero { get; private set; }

        public virtual string AtendimentoExpressoCliente { get; private set; }

        public virtual string LojaOperacao { get; private set; }

        public Reserva(Condutor condutor, string lojaOperacao)
        {            
            Condutor = condutor;
            LojaOperacao = lojaOperacao;
        }

        public void DefinirAtendimento(string tipo )
        {
            AtendimentoExpressoCliente = tipo;
        }

        public void DefinirNumeroReserva()
        {
            Numero = new Random().Next(1, 999);
        }

        public void AlterarStatus()
        {
        }

        public void Alterar()
        {
        }


        #region Constantes

        public const string AtendimentoExpressoClienteRealizado = "S";
        public const string AtendimentoExpressoClienteNaoRealizado = "N";

        #endregion

    }
}
