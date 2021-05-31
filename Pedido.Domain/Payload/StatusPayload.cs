using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Domain.Payload
{
    public class StatusPayload
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public int ValorAprovado { get; set; }
        public string Pedido { get; set; }
    }
}
