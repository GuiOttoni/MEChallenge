using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Domain.Payload
{
    public class PedidoPayload
    {
        public string IdPedido { get; set; }
        public int[] IdItens { get; set; }
    }
}
