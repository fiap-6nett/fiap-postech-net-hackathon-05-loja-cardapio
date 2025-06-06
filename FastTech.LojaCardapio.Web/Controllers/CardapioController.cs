using Microsoft.AspNetCore.Mvc;

namespace FastTech.LojaCardapio.Web.Controllers
{
    [Route("api/[controller]")]
    public class CardapioController : ControllerBase
    {
        //Buscar todos
        [HttpGet]
        public IActionResult GetCardapio()
        {

            return Ok();
        }

        //Buscar por id
        [HttpGet("{id}")]
        public IActionResult GetCardapioById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            // Aqui você buscaria o item do cardápio pelo ID
            // Exemplo: var item = _cardapioService.GetById(id);
            // Se o item não for encontrado, retorne NotFound
            // if (item == null) return NotFound();
            return Ok(); // Retorne o item encontrado
        }

        //Cadastrar
        [HttpPost]
        public IActionResult CreateCardapio([FromBody] object cardapio)
        {
            if (cardapio == null)
            {
                return BadRequest("Dados inválidos.");
            }

            return Ok(); // Retorne o item criado
        }

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult UpdateCardapio(int id, [FromBody] object cardapio)
        {
            if (id <= 0 || cardapio == null)
            {
                return BadRequest("Dados inválidos.");
            }
            // Aqui você atualizaria o item do cardápio pelo ID
            // Exemplo: var updatedItem = _cardapioService.Update(id, cardapio);
            // Se o item não for encontrado, retorne NotFound
            // if (updatedItem == null) return NotFound();
            return Ok(); // Retorne o item atualizado
        }

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult DeleteCardapio(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            // Aqui você deletaria o item do cardápio pelo ID
            // Exemplo: var deleted = _cardapioService.Delete(id);
            // Se o item não for encontrado, retorne NotFound
            // if (!deleted) return NotFound();
            return Ok(); // Retorne uma confirmação de exclusão
        }
    }
}
