using System.ComponentModel.DataAnnotations;

namespace FastTech.LojaCardapio.Application.Dtos.MenuItems
{
    public class UpdateMenuItemsStatusDto
    {
        [Required(ErrorMessage = "The IdMenuItem field is required.")]
        public Guid IdMenuItem { get; set; }
        public bool IsAvailable { get; set; } 
    }
}
