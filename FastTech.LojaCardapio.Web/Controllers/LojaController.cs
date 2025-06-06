using Microsoft.AspNetCore.Mvc;

namespace FastTech.LojaCardapio.Web.Controllers
{
    [Route("api/[controller]")]
    public class LojaController : ControllerBase
    {
        //Buscar todos
        [HttpGet]
        public IActionResult GetLojas()
        {
            return Ok(); // Retorne a lista de lojas
        }
        //Buscar por id
        [HttpGet("{id}")]
        public IActionResult GetLojaById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            // Aqui você buscaria a loja pelo ID
            // Exemplo: var loja = _lojaService.GetById(id);
            // Se a loja não for encontrada, retorne NotFound
            // if (loja == null) return NotFound();
            return Ok(); // Retorne a loja encontrada
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
        [HttpPut("{id}")]
        public IActionResult UpdateLoja(int id, [FromBody] object loja)
        {
            if (id <= 0 || loja == null)
            {
                return BadRequest("Dados inválidos.");
            }
            // Aqui você atualizaria a loja pelo ID
            // Exemplo: var updatedLoja = _lojaService.Update(id, loja);
            // Se a loja não for encontrada, retorne NotFound
            // if (updatedLoja == null) return NotFound();
            return Ok(); // Retorne a loja atualizada
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
