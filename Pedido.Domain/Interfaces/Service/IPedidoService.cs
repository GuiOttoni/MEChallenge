using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Domain.Interfaces.Service
{
    public interface IPedidoService
    {

        public Task AdicionaPedido(Model.Pedido pedido);
        public Task<Domain.Model.Pedido> BuscaPedido(string idPedido);
        public Task AtualizaPedido(Model.Pedido pedido);
        public Task DeletaPedido(string idPedido);
        public Task<IEnumerable<Model.Pedido>> BuscaTodosPedidos();
    }
}
