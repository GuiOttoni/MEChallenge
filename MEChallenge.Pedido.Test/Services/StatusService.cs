using NUnit.Framework;
using MEChallenge.Pedido.Infra.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MEChallenge.Pedido.Domain.Interfaces.Service;
using MEChallenge.Pedido.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using MEChallenge.Core;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Infra.Services.Tests
{
    [TestFixture()]
    public class StatusService
    {
        private IStatusService _statusService;
        private IPedidoRepository _pedidoRepository;
        private IConfiguration _configuration;

        [SetUp]
        public void Init()
        {
            _configuration = TestHelper.BuildConfiguration(TestContext.CurrentContext.TestDirectory );
            _pedidoRepository = new Infra.Repository.PedidoRepository(_configuration);
            _statusService = new Infra.Services.StatusService(_pedidoRepository);
        }

        [Test()]
        public void StatusServiceTest()
        {
            Assert.Fail();
        }

        [Test()]
        public async Task VerificarStatusReprovadoTest()
        {
            var resultado = await _statusService.VerificarStatus(new Domain.Payload.StatusPayload()
            {
                Pedido = "teste",
                ItensAprovados = 0,
                ValorAprovado = 0,
                Status = "REPROVADO"
            });

            Assert.IsTrue(resultado.Status.Contains("REPROVADO"));
        }

        [Test()]
        public void VerificaStatusTest()
        {
            Assert.Fail();
        }
    }
}


