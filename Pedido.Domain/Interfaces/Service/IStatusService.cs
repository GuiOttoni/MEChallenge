using MEChallenge.Pedido.Domain.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Domain.Interfaces.Service
{
    public interface IStatusService
    {
        public Task<StatusResponse> VerificarStatus(StatusPayload status);
    }
}
