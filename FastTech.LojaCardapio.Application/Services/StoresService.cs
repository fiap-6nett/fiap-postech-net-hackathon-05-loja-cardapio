using FastTech.LojaCardapio.Application.Configurations;
using FastTech.LojaCardapio.Application.Dtos.Stores;
using FastTech.LojaCardapio.Application.Interfaces;
using FastTech.LojaCardapio.Domain.Entities;
using Microsoft.Extensions.Options;

namespace FastTech.LojaCardapio.Application.Services
{
    public class StoresService : IStoresService
    {
        private readonly IAsyncRabbitMqProducer _asyncRabbitMqProducer;
        private readonly RabbitMQSettings _settings;

        public StoresService(IAsyncRabbitMqProducer asyncRabbitMqProducer,
            IOptions<RabbitMQSettings> settings)
        {
            _asyncRabbitMqProducer = asyncRabbitMqProducer;
            _settings = settings.Value;
        }

        public Task CreateStoreAsync(CreateStoreDto dto)
        {
            var id = Guid.NewGuid();
            var store = new StoresEntity();
            store.SetIdStore(id);
            store.SetName(dto.Name, dto.CreatedAt);
            store.SetLocation(dto.Location, dto.CreatedAt);
            store.SetIsAvailable(dto.IsAvailable);

            _asyncRabbitMqProducer.EnviarMensagem(_settings.Queues.StoreCreate, store);

            return Task.CompletedTask;
        }

        public Task UpdateStoreAsync(UpdateStoreDto dto)
        {
            var store = new StoresEntity();
            store.SetIdStore(dto.IdStore);
            store.SetName(dto.Name, dto.LastUpdatedAt);
            store.SetLocation(dto.Location, dto.LastUpdatedAt);

            _asyncRabbitMqProducer.EnviarMensagem(_settings.Queues.StoreUpdate, store);

            return Task.CompletedTask;

        }

        public Task UpdateStoreStatusAsync(UpdateStoreStatusDto dto)
        {
            var store = new StoresEntity();
            store.SetIdStore(dto.IdStore);
            store.SetIsAvailable(dto.IsAvailable);
            
            _asyncRabbitMqProducer.EnviarMensagem(_settings.Queues.StoreStatusUpdate, store);
                    
            return Task.CompletedTask; 
        }
    }
}
