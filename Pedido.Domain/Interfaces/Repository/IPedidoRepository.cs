using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Domain.Interfaces.Repository
{
    public interface IPedidoRepository
    {
        public Task AdicionaPedido(Model.Pedido);
        public Task BuscaPedido(string idPedido);
        public Task AtualizaPedido(Model.Pedido pedido);
        public Task DeletaPedido(string idPedido);
        public Task BuscaTodosPedidos();
    }
}
