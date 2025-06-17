using FastTech.LojaCardapio.Domain.Enums;


namespace FastTech.LojaCardapio.Domain.Entities
{
    public class MenuItemsEntity : BaseEntity
    {
        public Guid IdMenuItem { get; protected set; }
        public Guid IdStore { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }
        public CategoryEnums Category { get; protected set; }

        //Navegação
        public virtual StoresEntity Store { get; protected set; }


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

        public void SetIdMenuItem(Guid idMenuItem)
        {
            try
            {
                IdMenuItem = idMenuItem;
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
                throw new ArgumentException("Name must be between 3 and 100 characters.");

            Name = name;
         }

        public void SetDescription(string description) {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty or null.");
            if (description.Length < 3 || description.Length > 500)
                throw new ArgumentException("Description must be between 10 and 500 characters.");
            Description = description;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.");
            Price = price;
        }
        public void SetCategory(CategoryEnums category)
        {
            if (!Enum.IsDefined(typeof(CategoryEnums), (int) category))
                throw new ArgumentException("Invalid category.");
            Category = category;
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
