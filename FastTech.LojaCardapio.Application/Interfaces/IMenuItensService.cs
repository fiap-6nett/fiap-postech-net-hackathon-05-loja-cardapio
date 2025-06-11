using FastTech.LojaCardapio.Application.Dtos.MenuItems;

namespace FastTech.LojaCardapio.Application.Interfaces
{
    public interface IMenuItensService
    {
        Task UpdateMenuItemsAsync(UpdateMenuItemsDto dto);
        Task CreateMenuItemsAsync(CreateMenuItemsDto dto);
        Task UpdateMenuItemsStatusAsync(UpdateMenuItemsStatusDto dto);
    }
}
