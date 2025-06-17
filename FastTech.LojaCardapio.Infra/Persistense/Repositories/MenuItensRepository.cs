using FastTech.LojaCardapio.Application.Dtos.MenuItems;
using FastTech.LojaCardapio.Application.Interfaces.Repository;
using FastTech.LojaCardapio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastTech.LojaCardapio.Infra.Persistense.Repositories
{
    public class MenuItensRepository : IMenuItensRepository
    {
        private readonly LojaCardapioDbContext _context;

        public MenuItensRepository(LojaCardapioDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MenuItemsEntity menuItens)
        {
            _context.MenuItems.Add(menuItens);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MenuItemsEntity>> GetAvailableAsync()
        {
            return await _context.MenuItems
                .Include(m => m.Store)
                .Where(m => m.IsAvailable)
                .ToListAsync();

        }

        public async Task<MenuItemsEntity?> GetByIdAsync(Guid id)
        {
            return await _context.MenuItems
                .Include(m => m.Store)
                .Where(m => m.IsAvailable && m.IdMenuItem == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(MenuItemsEntity menuItens)
        {
            _context.MenuItems.Update(menuItens);
            await _context.SaveChangesAsync();
        }

    }
}
