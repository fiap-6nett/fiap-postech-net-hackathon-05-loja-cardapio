using FastTech.LojaCardapio.Application.Dtos;
using FastTech.LojaCardapio.Application.Dtos.MenuItems;
using FastTech.LojaCardapio.Application.Dtos.Stores;
using FastTech.LojaCardapio.Application.Interfaces.Services;
using FastTech.LojaCardapio.Application.Services;
using FastTech.LojaCardapio.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
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
        /// Busca Todos os items no banco de dados.
        /// </summary>
        [Authorize]
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ResponseStoreDto>>> GetAllAvailable()
        {
            var items = await _menuItensService.GetAllAvailableMenuItemAsync();
            return Ok(items);
        }

        /// <summary>
        /// Busca o Item do cardápio por Id no banco de dados.
        /// </summary>
        [Authorize]
        [HttpGet("[action]/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseStoreDto>> GetById(Guid id)
        {
            try
            {
                var items = await _menuItensService.GetAvailableMenuItemByIdAsync(id);
                return Ok(items);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError($"Item não encontrada: {ex.Message}");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Cadastra o Item do Cardápio e envia para o Banco de dados
        /// </summary>
        //Cadastrar
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
            catch (NotFoundException ex)
            {
                _logger.LogError($"Falha no endpoint CreateCardapio. Erro: {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha no endpoint CreateCardapio. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }

        /// <summary>
        /// Atualiza o Item do Cardápio e envia para o Banco de dados
        /// </summary>
        //Atualizar
        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
            catch (NotFoundException ex)
            {
                _logger.LogError($"Falha no endpoint UpdateCardapio. Erro: {ex.Message}");
                return NotFound(ex.Message);
            }   
            catch (Exception ex)
            {

                _logger.LogError($"Falha no endpoint UpdateCardapio. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }

        /// <summary>
        /// Envia o Id do Item do Cardápio para a atualização do status no banco de dados
        /// </summary>
        //Deletar
        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
            catch (NotFoundException ex)
            {
                _logger.LogError($"Falha no endpoint UpdateStatusCardapio. Erro: {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Falha no endpoint UpdateStatusCardapio. Erro{ex}");
                return StatusCode(500, $"Internal server error - {ex}");
            }
        }
    }
}

