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
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService) : base()
        {
            _statusService = statusService;
        }

        // POST api/<StatusController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Payload.StatusPayload status)
        {
            try
            {
                return Ok(await _statusService.VerificarStatus(status));
            }
            catch (Exception x)
            {
                return BadRequest();
            }
        }
    }
}
