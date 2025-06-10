namespace FastTech.LojaCardapio.Domain.Entities
{
    public class StoresEntity : BaseEntity
    {
        public Guid IdStore { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

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

        public void SetName(string name, DateTime lastUpdatedAt)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty or null.");

            if (name.Length < 3 || name.Length > 100)
                throw new ArgumentException("Name must be between 3 and 100 characters long.");
            Name = name;

        }

        public void SetLocation(string location, DateTime lastUpdatedAt)
        {
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Location cannot be empty or null.");
            if (location.Length < 3 || location.Length > 200)
                throw new ArgumentException("Location must be between 3 and 200 characters long.");
            Location = location;
        }

        #endregion
    }

}

