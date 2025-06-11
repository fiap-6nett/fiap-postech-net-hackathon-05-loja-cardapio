using FastTech.LojaCardapio.Application.Dtos.Stores;

namespace FastTech.LojaCardapio.Application.Interfaces
{
    public interface IStoresService
    {
        Task UpdateStoreAsync(UpdateStoreDto dto);
        Task CreateStoreAsync(CreateStoreDto dto);
        Task UpdateStoreStatusAsync(UpdateStoreStatusDto dto);

    }
}
