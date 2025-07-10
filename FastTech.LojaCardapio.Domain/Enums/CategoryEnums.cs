using System.ComponentModel.DataAnnotations;

namespace FastTech.LojaCardapio.Domain.Enums
{
    public enum CategoryEnums
    {
        [Display(Name = "Snack")]
        Snack = 0,

        [Display(Name = "Dessert")]
        Drink = 1,

        [Display(Name = "Drink")]
        Dessert = 2
    }
}
