using Dapper;
using MEChallenge.Core;
using MEChallenge.Pedido.Domain.Interfaces.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Infra.Repository
{
    public class PedidoRepository : BaseRepository ,IPedidoRepository
    {
        
        public PedidoRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task AdicionaPedido(Domain.Model.Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public async Task AtualizaPedido(Domain.Model.Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Model.Pedido> BuscaPedido(string idPedido)
        {
            throw new NotImplementedException();
        } 

        public async Task<IEnumerable<Domain.Model.Pedido>> BuscaTodosPedidos()
        {
            try
            {
                using SqliteConnection sqlConnection = new SqliteConnection(_connectionString);

                return await sqlConnection.QueryAsync<Domain.Model.Pedido>($"SELECT * FROM [Pedido]");
            }
            catch
            {
                //Add Logging
                throw;
            }
        }

        public async Task DeletaPedido(string idPedido)
        {
            throw new NotImplementedException();
        }
    }
}
