using MEChallenge.Core;
using MEChallenge.Pedido.Domain.Enum;
using MEChallenge.Pedido.Domain.Interfaces.Repository;
using MEChallenge.Pedido.Domain.Interfaces.Service;
using MEChallenge.Pedido.Domain.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Infra.Services
{
    public class StatusService : BaseService, IStatusService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public StatusService(IPedidoRepository pedidoRepository) : base()
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<StatusResponse> VerificarStatus(StatusPayload status)
        {
            var resposta = new StatusResponse();
            resposta.Status = new List<string>();

            var pedido = await _pedidoRepository.BuscaPedido(status.Pedido);

            if (pedido is null) {
                resposta.Pedido = status.Pedido;
                resposta.Status.Add(StatusEnum.CODIGO_PEDIDO_INVALIDO.ToString());
                return resposta;
            }

            var quantidadeItens = pedido.Itens.Sum(p => p.Qtd);
            var valorItens = pedido.Itens.Sum(x => Convert.ToDecimal(x.PrecoUnitario));

            return resposta;
        }
    }
}
