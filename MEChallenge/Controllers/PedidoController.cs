using MEChallenge.Pedido.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MEChallenge.Pedido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService) : base()
        {
            _pedidoService = pedidoService;
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _pedidoService.BuscaTodosPedidos());
            }
            catch(Exception x)
            {
                return BadRequest();
            } 
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await _pedidoService.BuscaPedido(id));
            }
            catch (Exception x)
            {
                return BadRequest();
            }
        }

        // POST api/<PedidoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Payload.PedidoPayload payload)
        {
            try
            {
                await _pedidoService.AdicionaPedido(payload);
            }
            catch (Exception x)
            {

            }
            return Ok();
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Domain.Payload.PedidoPayload payload)
        {
            try
            {
                await _pedidoService.AtualizaPedido(payload);
            }
            catch (Exception x)
            {

            }
            return Ok();
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _pedidoService.DeletaPedido(id);
            }
            catch (Exception x)
            {

            }
            return Ok();
        }
    }
}
