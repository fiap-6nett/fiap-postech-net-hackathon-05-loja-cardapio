using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace FastTech.LojaCardapio.Application.Dtos.Stores
{
    public class UpdateStoreStatusDto
    {
        [Required(ErrorMessage = "The IdStore field is required.")]
        public Guid IdStore { get; set; }

        [Required(ErrorMessage = "The LastUpdatedAt field is required.")]
        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsAvailable { get; set; } = false;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
