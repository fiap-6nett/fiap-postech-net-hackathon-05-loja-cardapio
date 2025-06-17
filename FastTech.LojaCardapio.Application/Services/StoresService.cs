using FastTech.LojaCardapio.Application.Dtos.Stores;
using FastTech.LojaCardapio.Application.Interfaces.Repository;
using FastTech.LojaCardapio.Application.Interfaces.Services;
using FastTech.LojaCardapio.Domain.Entities;
using FastTech.LojaCardapio.Domain.Exceptions;

namespace FastTech.LojaCardapio.Application.Services
{
    public class StoresService : IStoresService
    {
        private readonly IStoreRepository _storeRepository;

        public StoresService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task CreateStoreAsync(CreateStoreDto dto)
        {            
            var store = new StoresEntity();
            store.SetIdStore(Guid.NewGuid());
            store.SetName(dto.Name);
            store.SetLocation(dto.Location);
            store.SetCreatedAt(DateTime.UtcNow);
            store.SetLastUpdatedAt(DateTime.UtcNow);
            store.SetIsAvailable(true);

            await _storeRepository.AddAsync(store);
        }

        public async Task<List<ResponseStoreDto>> GetAllAvailableStoresAsync()
        {
            var stores = await _storeRepository.GetAvailableAsync();
            var response = stores.Select(s => new ResponseStoreDto
            {
                IdStore = s.IdStore,
                Name = s.Name,
                Location = s.Location,
                CreatedAt = s.CreatedAt,
                LastUpdatedAt = s.LastUpdatedAt
            }).ToList();

            return response;
        }

        public async Task<ResponseStoreDto> GetAvailableStoreByIdAsync(Guid id)
        {
            var store = await _storeRepository.GetByIdAsync(id);
            if (store == null)
                throw new NotFoundException("Loja não encontrada ou indisponível");

            return new ResponseStoreDto
            {
                IdStore = store.IdStore,
                Name = store.Name,
                Location = store.Location,
                CreatedAt = store.CreatedAt,
                LastUpdatedAt = store.LastUpdatedAt
            };
        }

        public async Task UpdateStoreAsync(UpdateStoreDto dto)
        {
            var store = await _storeRepository.GetByIdAsync(dto.IdStore);
            if (store == null)
                throw new NotFoundException("Loja não encontrada ou indisponível");

            store.SetName(dto.Name);
            store.SetLocation(dto.Location);
            store.SetLastUpdatedAt(DateTime.UtcNow);

            await _storeRepository.UpdateAsync(store);

        }

        public async Task UpdateStoreStatusAsync(UpdateStoreStatusDto dto)
        {
            var store = await _storeRepository.GetByIdAsync(dto.IdStore);
            if (store == null)
                throw new NotFoundException("Loja não encontrada ou indisponível");

            store.SetIsAvailable(dto.IsAvailable);
            store.SetLastUpdatedAt(DateTime.UtcNow);

            await _storeRepository.UpdateAsync(store);
        }
    }
}
