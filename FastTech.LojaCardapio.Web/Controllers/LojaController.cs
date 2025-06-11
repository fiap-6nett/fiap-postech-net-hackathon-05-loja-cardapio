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
        /// <summary>
        /// Envie a loja para a fila que será criada.
        /// </summary>
        //Cadastrar
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateLoja([FromBody] CreateStoreDto dto)
        {
            try
            {
                _logger.LogInformation($"Acessou {nameof(CreateStoreDto)}. Entrada: {dto}");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"Dados inválidos - Entrada: {dto}");
                    return BadRequest(ModelState);
                }

                await _storesService.CreateStoreAsync(dto);
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
                _logger.LogError($"Falha no endpoint CreateLoja. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }

        /// <summary>
        /// Envia a loja para a fila que será atualizado.
        /// </summary>
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
                };

                return Ok(response);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Falha no endpoint UpdateContato. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }
        /// <summary>
        /// Envia a loja para a fila que será atualizado o status IsAvailable.
        /// </summary>
        //UpdateStatus
        [HttpPut(("[action]"))]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStatusLoja([FromBody] UpdateStoreStatusDto dto)
        {
            try
            {
                _logger.LogInformation($"Acessou {nameof(UpdateStoreStatusDto)}. Entrada: {dto}");

                if (!ModelState.IsValid)
                {

                    _logger.LogWarning($"Dados inválidos - Entrada: {dto}");
                    return BadRequest(ModelState);
                }

                await _storesService.UpdateStoreStatusAsync(dto);
                _logger.LogInformation($"Dados Enviados para fila com sucesso");

                var response = new ResponseDto()
                {
                    Id = dto.IdStore,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha no endpoint UpdateStatusLoja. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }
    }
}
