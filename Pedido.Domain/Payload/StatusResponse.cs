using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Domain.Payload
{
    public class StatusResponse
    {
        public string Pedido { get; set; }
        public List<string> Status { get; set; }
    }
}
