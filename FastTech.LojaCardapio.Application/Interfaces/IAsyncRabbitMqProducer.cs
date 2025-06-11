namespace FastTech.LojaCardapio.Application.Interfaces
{
    public interface IAsyncRabbitMqProducer
    {
        Task EnviarMensagem(string nomeDaFila, object mensagem);
    }
}
