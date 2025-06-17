using FastTech.LojaCardapio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastTech.LojaCardapio.Infra.Persistense
{
    public class LojaCardapioDbContext : DbContext
    {
        public LojaCardapioDbContext(DbContextOptions<LojaCardapioDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Store
            modelBuilder.Entity<StoresEntity>()
                .HasKey(s => s.IdStore);
            base.OnModelCreating(modelBuilder);

            //MenuItem
            modelBuilder.Entity<MenuItemsEntity>()
                .HasKey(m => m.IdMenuItem);

            modelBuilder.Entity<MenuItemsEntity>()
                .HasOne(m => m.Store)
                .WithMany(s => s.MenuItems)
                .HasForeignKey(m => m.IdStore)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<StoresEntity> Stores { get; set; }
        public DbSet<MenuItemsEntity> MenuItems { get; set; }


    }
}
