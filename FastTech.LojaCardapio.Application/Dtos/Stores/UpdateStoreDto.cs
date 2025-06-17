using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace FastTech.LojaCardapio.Application.Dtos.Stores
{
    public class UpdateStoreDto
    {
        [Required(ErrorMessage = "The IdStore field is required.")]
        public Guid IdStore { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MinLength(3, ErrorMessage = "The Name field must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = "The Name field must not exceed 100 characters.")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "The Name field can only contain letters and numbers.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Location field is required.")]
        [MinLength(3, ErrorMessage = "The Location field must be at least 3 characters long.")]
        [MaxLength(200, ErrorMessage = "The Location field must not exceed 200 characters.")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s,]+$", ErrorMessage = "The Location field can only contain letters and numbers.")]
        public string Location { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
