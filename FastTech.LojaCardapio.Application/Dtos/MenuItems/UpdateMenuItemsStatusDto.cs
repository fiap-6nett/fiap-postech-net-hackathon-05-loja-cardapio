using System.ComponentModel.DataAnnotations;

namespace FastTech.LojaCardapio.Application.Dtos.MenuItems
{
    public class UpdateMenuItemsStatusDto
    {
        [Required(ErrorMessage = "The IdStore field is required.")]
        public Guid IdMenuItem { get; set; }

        [Required(ErrorMessage = "The IdStore field is required.")]
        public Guid IdStore { get; set; }
        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsAvailable { get; set; } 
    }
}
