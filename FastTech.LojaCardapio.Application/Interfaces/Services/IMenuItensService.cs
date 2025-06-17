using FastTech.LojaCardapio.Application.Dtos.MenuItems;
using FastTech.LojaCardapio.Application.Dtos.Stores;

namespace FastTech.LojaCardapio.Application.Interfaces.Services
{
    public interface IMenuItensService
    {
        Task UpdateMenuItemsAsync(UpdateMenuItemsDto dto);
        Task CreateMenuItemsAsync(CreateMenuItemsDto dto);
        Task UpdateMenuItemsStatusAsync(UpdateMenuItemsStatusDto dto);
        Task<List<ResponseMenuItemsDto>> GetAllAvailableMenuItemAsync();
        Task<ResponseMenuItemsDto> GetAvailableMenuItemByIdAsync(Guid id);

    }
}
