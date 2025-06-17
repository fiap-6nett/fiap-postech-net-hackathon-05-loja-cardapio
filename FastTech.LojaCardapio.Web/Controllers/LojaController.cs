using FastTech.LojaCardapio.Application.Dtos;
using FastTech.LojaCardapio.Application.Dtos.Stores;
using FastTech.LojaCardapio.Application.Interfaces.Services;
using FastTech.LojaCardapio.Domain.Exceptions;
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
        /// Busca Todas as lojas no banco de dados.
        /// </summary>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ResponseStoreDto>>> GetAllAvailable()
        {
            var stores = await _storesService.GetAllAvailableStoresAsync();
            return Ok(stores);
        }

        /// <summary>
        /// Busca a loja por Id no banco de dados.
        /// </summary>
        [HttpGet("[action]/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseStoreDto>> GetById(Guid id)
        {
            try
            {
                var store = await _storesService.GetAvailableStoreByIdAsync(id);
                return Ok(store);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError($"Loja não encontrada: {ex.Message}");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Cadastra uma nova loja no banco de dados.
        /// </summary>
        //Cadastrar
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
            catch (NotFoundException ex)
            {
                _logger.LogError($"Falha no endpoint CreateLoja. Erro: {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha no endpoint CreateLoja. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }

        /// <summary>
        /// Atualiza a loja no Banco de dados.
        /// </summary>
        //Atualizar
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
            catch (NotFoundException ex)
            {
                _logger.LogError($"Falha no endpoint UpdateLoja. Erro: {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Falha no endpoint UpdateContato. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }
        /// <summary>
        /// Altera o status da loja IsAvailable.
        /// </summary>
        //UpdateStatus
        [HttpPut(("[action]"))]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
            catch (NotFoundException ex)
            {
                _logger.LogError($"Falha no endpoint UpdateStatusLoja. Erro: {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha no endpoint UpdateStatusLoja. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }
    }
}
