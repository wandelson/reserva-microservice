using Unidas.Core.Entities;

namespace Unidas.CentralDeReservas.Dominio.Reservas.Entities
{
    public  class Condutor  : Entity
    {
        public Condutor()
        {

        }

        public virtual string Nome{ get; private set; }

        public Condutor(string nome)
        {
            Nome = nome;
        }
    }
}
