namespace FastTech.LojaCardapio.Domain.Entities
{
    public abstract class BaseEntity
    {

        public bool? IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }


    }
}
