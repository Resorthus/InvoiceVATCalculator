using CoreServices.Dtos.Client;
using CoreServices.Dtos.Country;
using CoreServices.Dtos.Supplier;
using CoreServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ITransactionParticipantService _service;

        public ClientsController(ITransactionParticipantService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateClientDto request)
        {
            var result = await _service.CreateClient(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _service.GetAllClients();
            return Ok(result);
        }
    }
}
