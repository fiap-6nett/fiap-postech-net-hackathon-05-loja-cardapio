using FastTech.LojaCardapio.Domain.Enums;


namespace FastTech.LojaCardapio.Domain.Entities
{
    public class MenuItemsEntity : BaseEntity
    {
        public Guid IdMenuItem { get; private set; }
        public Guid IdStore { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public CategoryEnums Category { get; private set; }

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
            if (description.Length < 10 || description.Length > 500)
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


        #endregion

    }
}
