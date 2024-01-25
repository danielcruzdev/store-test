using API.Store.Domain.Dtos.Request;
using API.Store.Domain.Dtos.Responses;
using API.Store.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Store.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoApplication _pedidoApplication;

        public PedidoController(IPedidoApplication pedidoApplication)
        {
            _pedidoApplication = pedidoApplication;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PedidoDto>), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoApplication.GetAll();

            if (!pedidos.Any())
                return NoContent();

            return Ok(pedidos);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PedidoDto), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var pedido = await _pedidoApplication.GetById(id);

            if(pedido is null)
                return NoContent();

            return Ok(pedido);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(ModelValidationState), 400)]
        public async Task<IActionResult> Insert([FromBody] PedidoInsertRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ValidationState);

            var response = await _pedidoApplication.Insert(request);
            return Ok(response);        
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(ModelValidationState), 400)]
        public async Task<IActionResult> Update([FromBody] PedidoUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ValidationState);

            var response = await _pedidoApplication.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var response = await _pedidoApplication.Delete(id);
            return Ok(response);
        }
    }
}