using FastTech.LojaCardapio.Application.Configurations;
using FastTech.LojaCardapio.Application.Dtos.MenuItems;
using FastTech.LojaCardapio.Application.Interfaces;
using FastTech.LojaCardapio.Domain.Entities;
using Microsoft.Extensions.Options;

namespace FastTech.LojaCardapio.Application.Services
{
    public class MenuItensService : IMenuItensService
    {
        private readonly IAsyncRabbitMqProducer _asyncRabbitMqProducer;
        private readonly RabbitMQSettings _settings;
        public MenuItensService(IAsyncRabbitMqProducer asyncRabbitMqProducer,
            IOptions<RabbitMQSettings> settings)
        {
            _asyncRabbitMqProducer = asyncRabbitMqProducer;
            _settings = settings.Value;
        }

        public Task CreateMenuItemsAsync(CreateMenuItemsDto dto)
        {
            var id = Guid.NewGuid();
            var menuItens = new MenuItemsEntity();
            menuItens.SetIdMenuItem(id);
            menuItens.SetIdStore(dto.IdStore);
            menuItens.SetName(dto.Name);
            menuItens.SetDescription(dto.Description);
            menuItens.SetPrice(dto.Price);
            menuItens.SetCategory(dto.Category);
            menuItens.SetIsAvailable(dto.IsAvailable);

            _asyncRabbitMqProducer.EnviarMensagem(_settings.Queues.MenuItensCreate, menuItens);

            return Task.CompletedTask;
        }

        public Task UpdateMenuItemsAsync(UpdateMenuItemsDto dto)
        {
            var menuItens = new MenuItemsEntity();
            menuItens.SetIdMenuItem(dto.IdMenuItem);
            menuItens.SetIdStore(dto.IdStore);
            menuItens.SetName(dto.Name);
            menuItens.SetDescription(dto.Description);
            menuItens.SetPrice(dto.Price);
            menuItens.SetCategory(dto.Category);

            _asyncRabbitMqProducer.EnviarMensagem(_settings.Queues.MenuItensUpdate, menuItens);

            return Task.CompletedTask;
        }

        public Task UpdateMenuItemsStatusAsync(UpdateMenuItemsStatusDto dto)
        {
            var menuItens = new MenuItemsEntity();
            menuItens.SetIdMenuItem(dto.IdMenuItem);
            menuItens.SetIdStore(dto.IdStore);
            menuItens.SetIsAvailable(dto.IsAvailable);

            _asyncRabbitMqProducer.EnviarMensagem(_settings.Queues.MenuItensStatusUpdate, menuItens);

            return Task.CompletedTask;
        }
    }
}
