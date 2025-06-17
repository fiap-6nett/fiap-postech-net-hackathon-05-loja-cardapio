using FastTech.LojaCardapio.Application.Dtos.Stores;

namespace FastTech.LojaCardapio.Application.Interfaces.Services
{
    public interface IStoresService
    {
        Task UpdateStoreAsync(UpdateStoreDto dto);
        Task CreateStoreAsync(CreateStoreDto dto);
        Task UpdateStoreStatusAsync(UpdateStoreStatusDto dto);
        Task<List<ResponseStoreDto>> GetAllAvailableStoresAsync();
        Task<ResponseStoreDto> GetAvailableStoreByIdAsync(Guid id);

    }
}
