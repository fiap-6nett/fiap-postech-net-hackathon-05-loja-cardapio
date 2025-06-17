using FastTech.LojaCardapio.Application.Dtos.MenuItems;
using FastTech.LojaCardapio.Domain.Entities;

namespace FastTech.LojaCardapio.Application.Interfaces.Repository
{
    public interface IMenuItensRepository 
    {
        Task AddAsync(MenuItemsEntity menuItens);
        Task<MenuItemsEntity?> GetByIdAsync(Guid id);
        Task UpdateAsync(MenuItemsEntity menuItens);
        Task<List<MenuItemsEntity>> GetAvailableAsync();
    }
}
