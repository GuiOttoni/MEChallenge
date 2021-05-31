using Dapper;
using MEChallenge.Core;
using MEChallenge.Pedido.Domain.Interfaces.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Infra.Repository
{
    public class PedidoRepository : BaseRepository ,IPedidoRepository
    {
        
        public PedidoRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task AdicionaPedido(Domain.Payload.PedidoPayload pedido)
        {
            try
            {
                using SqliteConnection sqlConnection = new SqliteConnection(_connectionString);

                await sqlConnection.ExecuteAsync(@$"INSERT INTO Pedido (
                       IdPedido
                   )
                   VALUES(
                       @IdPedido
                   ); ", new { IdPedido = pedido.IdPedido });
            }
            catch
            {
                //Add Logging
                throw;
            }
        }

        public async Task AdicionaItemPedido(string IdPedido, int IdItem)
        {
            try
            {
                using SqliteConnection sqlConnection = new SqliteConnection(_connectionString);

                await sqlConnection.ExecuteAsync(@$"INSERT INTO ItensPedido (
                            IdPedido,
                            IdItem
                        )
                        VALUES (
                            @IdPedido,
                            @IdItem
                        );", new { IdPedido = IdPedido, IdItem = IdItem });
            }
            catch
            {
                //Add Logging
                throw;
            }
        }

        public async Task AtualizaPedido(Domain.Model.Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Model.Pedido> BuscaPedido(string idPedido)
        {
            string query = $@"select P.IdPedido, P.Status, IP.*, I.Descricao, I.PrecoUnitario from Pedido P
inner join ItensPedido IP on P.IdPedido = IP.IdPedido 
inner join Item I on IP.IdItem = I.IdItem 
                              Where P.IdPedido = @IdPedido";

            var itens = new List<Domain.Model.Item>();

            try
            {
                using SqliteConnection sqlConnection = new SqliteConnection(_connectionString);
                var x = await sqlConnection.QueryAsync<Domain.Model.Pedido, Domain.Model.Item, Domain.Model.Pedido>(query,
                    (P, IP) =>
                    {
                        itens.Add(IP);
                        return P;
                    },
                    param: new { IdPedido = idPedido },
                    splitOn: "IdPedido");
                var pedido = x.AsList().FirstOrDefault();

                if (pedido is not null)
                {
                    pedido.Itens = itens.GroupBy(x => x.IdItem).Select(p => {
                        var item = p.FirstOrDefault();
                        item.Qtd = p.Count();
                        return item;
                    }).ToList();
                }

                return pedido;
            }
            catch
            {
                //Add Logging
                throw;
            }
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
            try
            {
                using SqliteConnection sqlConnection = new SqliteConnection(_connectionString);

                await sqlConnection.ExecuteAsync(@$"DELETE FROM ItensPedido
                                                    WHERE IdPedido = @IdPedido
                        ", new { IdPedido = idPedido });
            }
            catch
            {
                //Add Logging
                throw;
            }
        }

        public async Task DeletaItemPedido(string idPedido)
        {
            try
            {
                using SqliteConnection sqlConnection = new SqliteConnection(_connectionString);

                await sqlConnection.ExecuteAsync(@$"DELETE FROM Pedido
                                                    WHERE IdPedido = @IdPedido
                       ", new { IdPedido = idPedido });
            }
            catch
            {
                //Add Logging
                throw;
            }
        }
    }
}
