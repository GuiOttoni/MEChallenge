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
    public class StatusService : BaseService, IStatusService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public StatusService(IPedidoRepository pedidoRepository) : base()
        {
            _pedidoRepository = pedidoRepository;
        }
    }
}
