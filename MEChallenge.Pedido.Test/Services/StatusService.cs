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
using MEChallenge.Pedido.Domain.Enum;

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
        public async Task VerificaStatusAprovadoTest()
        {
            var resultado = await _statusService.VerificarStatus(new Domain.Payload.StatusPayload()
            {
                Pedido = "teste",
                ItensAprovados = 6,
                ValorAprovado = 60,
                Status = "APROVADO"
            });

            Assert.IsTrue(resultado.Status.Contains("APROVADO"));
        }

        [Test()]
        public async Task VerificaStatusAprovadoQtdMaiorTest()
        {
            var resultado = await _statusService.VerificarStatus(new Domain.Payload.StatusPayload()
            {
                Pedido = "teste",
                ItensAprovados = 7,
                ValorAprovado = 60,
                Status = "APROVADO"
            });

            Assert.IsTrue(resultado.Status.Contains(StatusEnum.APROVADO_QTD_A_MAIOR.ToString()));
        }

        [Test()]
        public async Task VerificaStatusAprovadoValorMaiorTest()
        {
            var resultado = await _statusService.VerificarStatus(new Domain.Payload.StatusPayload()
            {
                Pedido = "teste",
                ItensAprovados = 6,
                ValorAprovado = 70,
                Status = "APROVADO"
            });

            Assert.IsTrue(resultado.Status.Contains(StatusEnum.APROVADO_VALOR_A_MAIOR.ToString()));
        }

        [Test()]
        public async Task VerificaStatusAprovadoQtdMenorTest()
        {
            var resultado = await _statusService.VerificarStatus(new Domain.Payload.StatusPayload()
            {
                Pedido = "teste",
                ItensAprovados = 5,
                ValorAprovado = 60,
                Status = "APROVADO"
            });

            Assert.IsTrue(resultado.Status.Contains(StatusEnum.APROVADO_QTD_A_MENOR.ToString()));
        }

        [Test()]
        public async Task VerificaStatusAprovadoValorMenorTest()
        {
            var resultado = await _statusService.VerificarStatus(new Domain.Payload.StatusPayload()
            {
                Pedido = "teste",
                ItensAprovados = 6,
                ValorAprovado = 50,
                Status = "APROVADO"
            });

            Assert.IsTrue(resultado.Status.Contains(StatusEnum.APROVADO_VALOR_A_MENOR.ToString()));
        }
    }
}


