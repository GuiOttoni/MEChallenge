using System;
using System.Collections.Generic;
using System.Text;

namespace MEChallenge.Pedido.Domain.Model
{
    public class Pedido
    {
        public string IdPedido { get; set; }
        public string Status { get; set; }
        public List<Item> Itens { get; set; }
    }
}
