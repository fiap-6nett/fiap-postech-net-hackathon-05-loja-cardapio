namespace FastTech.LojaCardapio.Domain.Entities
{
    public class StoresEntity : BaseEntity
    {
        public Guid IdStore { get; protected set; }
        public string Name { get; protected set; }
        public string Location { get; protected set; }

        public virtual ICollection<MenuItemsEntity> MenuItems { get; protected set; } = new List<MenuItemsEntity>();


        #region validações
        public void SetIdStore(Guid idStore)
        {
            try
            {
                IdStore = idStore;
            }
            catch
            {
                throw new ArgumentException("Id invalido");
            }
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty or null.");

            if (name.Length < 3 || name.Length > 100)
                throw new ArgumentException("Name must be between 3 and 100 characters long.");
            Name = name;

        }

        public void SetLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Location cannot be empty or null.");
            if (location.Length < 3 || location.Length > 200)
                throw new ArgumentException("Location must be between 3 and 200 characters long.");
            Location = location;
        }

        public void SetIsAvailable(bool isAvailable)
        {
            IsAvailable = isAvailable;
        }

        public void SetLastUpdatedAt(DateTimeOffset lastUpdatedAt)
        {
            if (lastUpdatedAt == null || lastUpdatedAt == DateTime.MinValue)
                throw new ArgumentException("Last updated at cannot be null or default value.");
            LastUpdatedAt = lastUpdatedAt;
        }

        public void SetCreatedAt(DateTimeOffset createdAt)
        {
            if (createdAt == null || createdAt == DateTime.MinValue)
                throw new ArgumentException("Created at cannot be null or default value.");
            CreatedAt = createdAt;
        }

        #endregion
    }

}

