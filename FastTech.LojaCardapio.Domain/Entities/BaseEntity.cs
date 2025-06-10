namespace FastTech.LojaCardapio.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsAvailable = false;
            LastUpdatedAt = DateTime.Now;
        }

        public bool IsAvailable { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdatedAt { get; private set; }

        public void SetAsDeleted()
        {
            IsAvailable = true;
            LastUpdatedAt = DateTime.Now;
        }
    }
}
