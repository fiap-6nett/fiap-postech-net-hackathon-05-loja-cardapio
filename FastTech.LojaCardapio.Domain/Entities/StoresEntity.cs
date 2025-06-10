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
            Name = name;

        }

        public void SetLocation(string location, DateTime lastUpdatedAt)
        {
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Location cannot be empty or null.");
            Location = location;
        }

        #endregion
    }

}

