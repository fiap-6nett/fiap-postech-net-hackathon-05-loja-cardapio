namespace FastTech.LojaCardapio.Application.Dtos.Stores
{
    public class ResponseStoreDto
    {
        public Guid IdStore { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? LastUpdatedAt { get; set; }
    }
}
