using api_salles_manager.Domain;
using Microsoft.EntityFrameworkCore;

namespace api_salles_manager.Data
{
    public class VendasDbContext : DbContext
    {
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        public VendasDbContext(DbContextOptions<VendasDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>().HasKey(v => v.Id);
            modelBuilder.Entity<ItemVenda>().HasKey(i => i.Id);
        }
    }
}
