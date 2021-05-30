using MEChallenge.Core;
using MEChallenge.Pedido.Domain.Interfaces.Repository;
using MEChallenge.Pedido.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Infra.Services
{
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository) : base()
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task AdicionaPedido(Domain.Model.Pedido pedido)
        {
            await _pedidoRepository.AdicionaPedido(pedido);
        }

        public async Task AtualizaPedido(Domain.Model.Pedido pedido)
        {
            await _pedidoRepository.AtualizaPedido(pedido);
        }

        public async Task<Domain.Model.Pedido> BuscaPedido(string idPedido)
        {
            return await _pedidoRepository.BuscaPedido(idPedido);
        }

        public async Task<IEnumerable<Domain.Model.Pedido>> BuscaTodosPedidos()
        {
            return await _pedidoRepository.BuscaTodosPedidos();
        }

        public async Task DeletaPedido(string idPedido)
        {
            await _pedidoRepository.DeletaPedido(idPedido);
        }
    }
}
