using System.Threading.Tasks;
using Unidas.CentralDeReservas.Dominio.Reservas.Interfaces;
using Unidas.CentralDeReservas.Dominio.Reservas.Entities;
using Unidas.CentralDeReservas.Infra.Contexts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Unidas.CentralDeReservas.Aplicacao.Reservas.QuerySide.Result;

namespace Unidas.CentralDeReservas.Infra.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ReservaContext context;

        public ReservaRepository(ReservaContext context )
        {
            this.context = context;
        }

        public async Task<IEnumerable<ListarReservaResult>> Listar()
        {
            var conexao = context.Database.GetDbConnection();
            var sql = "SELECT RESNUM AS NumeroReserva, RESLOJOPE As LojaOperacao FROM RESTAB";
            return await conexao.QueryAsync<ListarReservaResult>(sql);            
        }

        public async Task  Salvar(Reserva reserva)
        {
            await context.Reservas.AddAsync(reserva);
        }
    }
}