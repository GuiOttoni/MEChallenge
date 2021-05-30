using MEChallenge.Core;
using MEChallenge.Pedido.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MEChallenge.Pedido.Infra.Repository
{
    public class PedidoRepository : BaseRepository ,IPedidoRepository
    {
        
        public PedidoRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
