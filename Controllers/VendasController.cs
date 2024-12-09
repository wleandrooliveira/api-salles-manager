using api_salles_manager.Domain;
using api_salles_manager.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_salles_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _service;

        public VendasController(IVendaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenda(Guid id)
        {
            var venda = await _service.ObterVendaPorId(id);
            return venda == null ? NotFound() : Ok(venda);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVenda([FromBody] Venda venda)
        {
            await _service.CriarVenda(venda);
            return CreatedAtAction(nameof(GetVenda), new { id = venda.Id }, venda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenda(Guid id, [FromBody] Venda vendaAtualizada)
        {
            try
            {
                await _service.AtualizarVenda(id, vendaAtualizada);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(Guid id)
        {
            try
            {
                await _service.DeletarVenda(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
