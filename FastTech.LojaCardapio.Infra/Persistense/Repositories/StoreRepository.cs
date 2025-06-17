using FastTech.LojaCardapio.Application.Interfaces.Repository;
using FastTech.LojaCardapio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastTech.LojaCardapio.Infra.Persistense.Repositories
{
    public class StoreRepository : IStoreRepository
    {

        private readonly LojaCardapioDbContext _context;

        public StoreRepository(LojaCardapioDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StoresEntity store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StoresEntity>> GetAvailableAsync()
        {
            return await _context.Stores
                .Where(s => s.IsAvailable == true)
                .ToListAsync();
        }
        public async Task<StoresEntity?> GetByIdAsync(Guid id)
        {
           return await _context.Stores.FirstOrDefaultAsync(s => s.IsAvailable && s.IdStore == id);
        }

        public async Task UpdateAsync(StoresEntity store)
        {
            _context.Stores.Update(store);
            await _context.SaveChangesAsync();
        }


    }
}
