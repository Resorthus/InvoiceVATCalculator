using CoreServices.Dtos.Client;
using CoreServices.Dtos.Supplier;
using CoreServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ITransactionParticipantService _service;

        public SupplierController(ITransactionParticipantService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSupplierDto request)
        {
            var result = await _service.CreateSupplier(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _service.GetAllSuppliers();
            return Ok(result);
        }
    }
}
