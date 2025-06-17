using FastTech.LojaCardapio.Domain.Entities;

namespace FastTech.LojaCardapio.Application.Interfaces.Repository
{
    public interface IStoreRepository
    {
        Task AddAsync(StoresEntity store);
        Task<StoresEntity?> GetByIdAsync(Guid id);
        Task UpdateAsync(StoresEntity store);
        Task<List<StoresEntity>> GetAvailableAsync();
    }
}
