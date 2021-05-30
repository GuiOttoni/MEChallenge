using MEChallenge.Core;
using MEChallenge.Pedido.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Infra.Repository
{
    public class StatusRepository : BaseRepository, IStatusRepository
    {
        public StatusRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
