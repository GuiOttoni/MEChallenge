﻿using MEChallenge.Core;
using MEChallenge.Pedido.Domain.Interfaces.Repository;
using MEChallenge.Pedido.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MEChallenge.Pedido.Infra.Services
{
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IStatusService _statusRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IStatusService statusRepository) : base()
        {
            _pedidoRepository = pedidoRepository;
            _statusRepository = statusRepository;
        }

        
    }
}