using MEChallenge.Core;
using MEChallenge.Pedido.Domain.Interfaces.Repository;
using MEChallenge.Pedido.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AdicionaPedido(Domain.Payload.PedidoPayload pedido)
        {
            await _pedidoRepository.AdicionaPedido(pedido);

            for (int i = 0; i < pedido.IdItens.Length; i++)
            {
                await _pedidoRepository.AdicionaItemPedido(pedido.IdPedido, pedido.IdItens[i]);
            }
        }

        public async Task AtualizaPedido(Domain.Model.Pedido pedido)
        {
            await _pedidoRepository.AtualizaPedido(pedido);
        }

        public async Task<Domain.Model.Pedido> BuscaPedido(string idPedido)
        {
            var ped = await _pedidoRepository.BuscaPedido(idPedido);

            ped.Itens = ped.Itens.GroupBy(x => x.IdItem).Select( p => {
                var item = p.FirstOrDefault();
                item.Qtd = p.Count();
                return item;
            }).ToList();

            return ped;
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
