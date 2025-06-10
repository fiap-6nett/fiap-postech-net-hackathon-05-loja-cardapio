using FastTech.LojaCardapio.Application.Dtos;
using FastTech.LojaCardapio.Application.Dtos.Stores;
using FastTech.LojaCardapio.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.LojaCardapio.Web.Controllers
{
    [Route("api/v1.0/[controller]")]
    public class LojaController : ControllerBase
    {
        private readonly ILogger<LojaController> _logger;
        private readonly IStoresService _storesService;

        public LojaController(ILogger<LojaController> logger, IStoresService storesService)
        {
            _logger = logger;
            _storesService = storesService;
        }

        //Cadastrar
        [HttpPost]
        public IActionResult CreateLoja([FromBody] object loja)
        {
            if (loja == null)
            {
                return BadRequest("Dados inválidos.");
            }
            return Ok(); // Retorne a loja criada
        }
        //Atualizar
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateLoja([FromBody] UpdateStoreDto dto)
        {
            try
            {
                _logger.LogInformation($"Acessou {nameof(UpdateStoreDto)}. Entrada: {dto}");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"Dados inválidos - Entrada: {dto}");
                    return BadRequest(ModelState);
                }

                await _storesService.UpdateStoreAsync(dto);
                _logger.LogInformation($"Dados Enviados para fila com sucesso");

                var response = new ResponseDto()
                {
                    Id = dto.IdStore,
                    CreatedAt = DateTime.UtcNow
                };

                return Ok(response);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Falha no endpoint UpdateContato. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }
        //Deletar
        [HttpDelete("{id}")]
        public IActionResult DeleteLoja(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            // Aqui você deletaria a loja pelo ID
            // Exemplo: var deleted = _lojaService.Delete(id);
            // Se a loja não for encontrada, retorne NotFound
            // if (!deleted) return NotFound();
            return Ok(); // Retorne sucesso na deleção
        }
    }
}
