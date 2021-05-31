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
            resposta.Pedido = status.Pedido;

            var pedido = await _pedidoRepository.BuscaPedido(status.Pedido);
            

            if (pedido is null) 
            {
                resposta.Status.Add(StatusEnum.CODIGO_PEDIDO_INVALIDO.ToString());
                return resposta;
            }

            if(status.Status == "REPROVADO")
            {
                resposta.Status.Add(StatusEnum.REPROVADO.ToString());
                return resposta;
            }

            if(status.Status == "APROVADO")
            {
                resposta.Status = VerificaStatus(pedido, status);
            }
            

            return resposta;
        }

        public List<string> VerificaStatus(Domain.Model.Pedido pedido, StatusPayload status)
        {
            var lista = new List<string>();
            var quantidadeItens = pedido.Itens.Sum(p => p.Qtd);
            var valorTotal = pedido.Itens.Sum(x => Convert.ToDecimal(x.PrecoUnitario) * x.Qtd);

            var qntdItem = status.ItensAprovados == quantidadeItens;
            var valor = status.ValorAprovado == valorTotal;
            var sts = status.Status == "APROVADO";

            if (sts)
                lista.Add(StatusEnum.APROVADO.ToString());
            if (qntdItem && valor && sts)
                lista.Add(StatusEnum.APROVADO.ToString());

            if (status.ValorAprovado < valorTotal)
                lista.Add(StatusEnum.APROVADO_VALOR_A_MENOR.ToString());
            else if (status.ValorAprovado > valorTotal)
                lista.Add(StatusEnum.APROVADO_VALOR_A_MAIOR.ToString());

            if (status.ItensAprovados > quantidadeItens)
                lista.Add(StatusEnum.APROVADO_QTD_A_MAIOR.ToString());
            else if (status.ItensAprovados < quantidadeItens)
                lista.Add(StatusEnum.APROVADO_QTD_A_MENOR.ToString());

            return lista;
        }
    }
}
