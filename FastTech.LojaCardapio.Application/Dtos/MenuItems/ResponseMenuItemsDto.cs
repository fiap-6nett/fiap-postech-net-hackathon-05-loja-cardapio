using FastTech.LojaCardapio.Domain.Enums;

namespace FastTech.LojaCardapio.Application.Dtos.MenuItems
{
    public class ResponseMenuItemsDto
    {
        public Guid IdMenuItem { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryEnums Category { get; set; }
        public string StoreName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? LastUpdatedAt { get; set; }
    }
}
