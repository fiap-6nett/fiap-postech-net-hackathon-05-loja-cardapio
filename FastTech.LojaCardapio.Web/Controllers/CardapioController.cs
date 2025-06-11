using FastTech.LojaCardapio.Application.Dtos;
using FastTech.LojaCardapio.Application.Dtos.MenuItems;
using FastTech.LojaCardapio.Application.Dtos.Stores;
using FastTech.LojaCardapio.Application.Interfaces;
using FastTech.LojaCardapio.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.LojaCardapio.Web.Controllers
{
    [Route("api/v1.0/[controller]")]
    public class CardapioController : ControllerBase
    {
        private readonly ILogger<CardapioController> _logger;
        private readonly IMenuItensService _menuItensService;
        public CardapioController(ILogger<CardapioController> logger, IMenuItensService menuItensService)
        {
            _logger = logger;
            _menuItensService = menuItensService;
        }

        /// <summary>
        /// Envie o cardápio para a fila que será criada.
        /// </summary>
        //Cadastrar
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCardapio([FromBody] CreateMenuItemsDto dto)
        {
            try
            {
                _logger.LogInformation($"Acessou {nameof(CreateMenuItemsDto)}. Entrada: {dto}");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"Dados inválidos - Entrada: {dto}");
                    return BadRequest(ModelState);
                }

                await _menuItensService.CreateMenuItemsAsync(dto);
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
                _logger.LogError($"Falha no endpoint CreateCardapio. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }

        /// <summary>
        /// Envia o cardápio para a fila que será atualizado.
        /// </summary>
        //Atualizar
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCardapio([FromBody] UpdateMenuItemsDto dto)
        {
            try
            {
                _logger.LogInformation($"Acessou {nameof(UpdateMenuItemsDto)}. Entrada: {dto}");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"Dados inválidos - Entrada: {dto}");
                    return BadRequest(ModelState);
                }

                await _menuItensService.UpdateMenuItemsAsync(dto);
                _logger.LogInformation($"Dados Enviados para fila com sucesso");

                var response = new ResponseDto()
                {
                    Id = dto.IdMenuItem,

                };

                return Ok(response);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Falha no endpoint UpdateCardapio. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }

        /// <summary>
        /// Envia o cardápio para a fila que será atualizado o status IsAvailable.
        /// </summary>
        //Deletar
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStatusCardapio([FromBody] UpdateMenuItemsStatusDto dto)
        {
            try
            {
                _logger.LogInformation($"Acessou {nameof(UpdateMenuItemsStatusDto)}. Entrada: {dto}");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"Dados inválidos - Entrada: {dto}");
                    return BadRequest(ModelState);
                }

                await _menuItensService.UpdateMenuItemsStatusAsync(dto);
                _logger.LogInformation($"Dados Enviados para fila com sucesso");

                var response = new ResponseDto()
                {
                    Id = dto.IdMenuItem,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha no endpoint UpdateStatusCardapio. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }
    }
}

