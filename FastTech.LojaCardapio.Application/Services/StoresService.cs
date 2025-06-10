using FastTech.LojaCardapio.Application.Dtos.Stores;
using FastTech.LojaCardapio.Application.Interfaces;
using FastTech.LojaCardapio.Domain.Entities;

namespace FastTech.LojaCardapio.Application.Services
{
    public class StoresService : IStoresService
    {
        private readonly IAsyncRabbitMqProducer _asyncRabbitMqProducer;

        public StoresService(IAsyncRabbitMqProducer asyncRabbitMqProducer)
        {
            _asyncRabbitMqProducer = asyncRabbitMqProducer;
        }
        public Task UpdateStoreAsync(UpdateStoreDto dto)
        {
            var store = new StoresEntity();
            store.SetIdStore(dto.IdStore);
            store.SetName(dto.Name, dto.LastUpdatedAt);
            store.SetLocation(dto.Location, dto.LastUpdatedAt);

            _asyncRabbitMqProducer.EnviarMensagem(store);

            return Task.CompletedTask;

        }
    }
}
