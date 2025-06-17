using FastTech.LojaCardapio.Application.Validations;
using FastTech.LojaCardapio.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace FastTech.LojaCardapio.Application.Dtos.MenuItems
{
    public class CreateMenuItemsDto
    {
        [Required(ErrorMessage = "The IdStore field is required.")]
        public Guid IdMenuItem { get; set; }

        [Required(ErrorMessage = "The IdStore field is required.")]
        public Guid IdStore { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MinLength(3, ErrorMessage = "The Name field must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = "The Name field must not exceed 100 characters.")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "The Name field can only contain letters and numbers.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [MinLength(3, ErrorMessage = "The Description field must be at least 3 characters long.")]
        [MaxLength(200, ErrorMessage = "The Description field must not exceed 200 characters.")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]+$", ErrorMessage = "The Location field can only contain letters and numbers.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0.01, 10000, ErrorMessage = "The Price field must be between 0.01 and 10,000.")]
        [TwoDecimalPlaces(ErrorMessage = "The Price field must have up to two decimal places.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Category field is required.")]
        [EnumDataType(typeof(CategoryEnums), ErrorMessage = "The Category field must be a valid category.")]
        public CategoryEnums Category { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
