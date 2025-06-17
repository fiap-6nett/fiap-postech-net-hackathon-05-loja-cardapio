using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace FastTech.LojaCardapio.Application.Dtos.Stores
{
    public class UpdateStoreStatusDto
    {
        [Required(ErrorMessage = "The IdStore field is required.")]
        public Guid IdStore { get; set; }
        public bool IsAvailable { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
