using System;
using System.Collections.Generic;
using System.Text;

namespace MEChallenge.Pedido.Domain.Model
{
    public class Item
    {
        public string Descricao { get; set; }
        public string PrecoUnitario { get; set; }
        public int Qtd { get; set; }
    }
}
