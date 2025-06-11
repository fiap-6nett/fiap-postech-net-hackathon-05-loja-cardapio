namespace FastTech.LojaCardapio.Application.Configurations
{
    public class RabbitMQSettings
    {
        public string Host { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string VirtualHost { get; set; } = "/";
        public LojaCardapioFilaService Queues { get; set; }
    }
}
