using FastTech.LojaCardapio.Application.Dtos;
using FastTech.LojaCardapio.Application.Dtos.Stores;
using FastTech.LojaCardapio.Application.Interfaces;
using FastTech.LojaCardapio.Infra.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
        /// <param name="dto">Dados da loja a serem criados.</param>
        /// <returns>Retorna o ID.</returns>
        /// <response code="200">Loja criada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        //Cadastrar
        [HttpPost("[action]")]
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
        /// <param name="dto">Dados da loja a serem atualizados.</param>
        /// <returns>Retorna o ID.</returns>
        /// <response code="200">Loja atualizada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
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
        /// <param name="dto">Status da loja a serem atualizados.</param>
        /// <returns>Retorna o ID.</returns>
        /// <response code="200">Status da Loja atualizada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        //Deletar
        [HttpPut(("[action]"))]
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
