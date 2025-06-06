namespace FastTech.LojaCardapio.Application.Interfaces
{
    public interface IAsyncRabbitMqProducer
    {
        Task EnviarMensagem(object mensagem);
    }
}
