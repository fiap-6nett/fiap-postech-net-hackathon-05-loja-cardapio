using FastTech.LojaCardapio.Application.Dtos.MenuItems;
using FastTech.LojaCardapio.Application.Interfaces.Repository;
using FastTech.LojaCardapio.Application.Interfaces.Services;
using FastTech.LojaCardapio.Domain.Entities;
using FastTech.LojaCardapio.Domain.Exceptions;

namespace FastTech.LojaCardapio.Application.Services
{
    public class MenuItensService : IMenuItensService
    {
        private readonly IMenuItensRepository _menuItensRepository;
        private readonly IStoreRepository _storeRepository;

        public MenuItensService(IMenuItensRepository menuItensRepository, IStoreRepository storeRepository)
        {
            _menuItensRepository = menuItensRepository;
            _storeRepository = storeRepository;
        }

        public async Task CreateMenuItemsAsync(CreateMenuItemsDto dto)
        {
            var store = await _storeRepository.GetByIdAsync(dto.IdStore);
            if (store == null)
                throw new NotFoundException("Loja não encontrada ou Indisponível.");

            var id = Guid.NewGuid();
            var menuItens = new MenuItemsEntity();
            menuItens.SetIdMenuItem(id);
            menuItens.SetIdStore(dto.IdStore);
            menuItens.SetName(dto.Name);
            menuItens.SetDescription(dto.Description);
            menuItens.SetPrice(dto.Price);
            menuItens.SetCategory(dto.Category);
            menuItens.SetCreatedAt(DateTime.UtcNow);
            menuItens.SetLastUpdatedAt(DateTime.UtcNow);
            menuItens.SetIsAvailable(true);
            
                     
            await _menuItensRepository.AddAsync(menuItens);
        }

        public async Task<List<ResponseMenuItemsDto>> GetAllAvailableMenuItemAsync()
        {
            var items = await _menuItensRepository.GetAvailableAsync();

            return items.Select(m => new ResponseMenuItemsDto
            {
                IdMenuItem = m.IdMenuItem,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                Category = m.Category,
                CreatedAt = m.CreatedAt,
                LastUpdatedAt = m.LastUpdatedAt,
                StoreName = m.Store?.Name ?? "Loja Indisponível"
            }).ToList();

        }

        public async Task<ResponseMenuItemsDto> GetAvailableMenuItemByIdAsync(Guid id)
        {
            var item = await _menuItensRepository.GetByIdAsync(id);
            if (item == null)
                throw new NotFoundException("Item do Menu não encontrado ou Indisponível.");

            return new ResponseMenuItemsDto
            {
                IdMenuItem = item.IdMenuItem,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Category = item.Category,
                CreatedAt = item.CreatedAt,
                LastUpdatedAt = item.LastUpdatedAt,
                StoreName = item.Store?.Name ?? "Loja Indisponível"
            };
        }

        public async Task UpdateMenuItemsAsync(UpdateMenuItemsDto dto)
        {
           
            var menuItens = await _menuItensRepository.GetByIdAsync(dto.IdMenuItem);
            if (menuItens == null)
                throw new NotFoundException("Item do Menu não encontrado ou Indisponível.");
                                  
            menuItens.SetIdMenuItem(dto.IdMenuItem);
            menuItens.SetName(dto.Name);
            menuItens.SetDescription(dto.Description);
            menuItens.SetPrice(dto.Price);
            menuItens.SetCategory(dto.Category);
            menuItens.SetLastUpdatedAt(DateTime.UtcNow);

            await _menuItensRepository.UpdateAsync(menuItens);
        }

        public async Task UpdateMenuItemsStatusAsync(UpdateMenuItemsStatusDto dto)
        {
            var menuItens = await _menuItensRepository.GetByIdAsync(dto.IdMenuItem);
            if (menuItens == null)
                throw new NotFoundException("Item do Menu não encontrado ou Indisponível.");

            menuItens.SetIdMenuItem(dto.IdMenuItem);
            menuItens.SetIsAvailable(dto.IsAvailable);
            menuItens.SetLastUpdatedAt(DateTime.UtcNow);

            await _menuItensRepository.UpdateAsync(menuItens);
        }
    }
}
