using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace api_salles_manager.Data
{
    public class VendasDbContextFactory : IDesignTimeDbContextFactory<VendasDbContext>
    {
        public VendasDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VendasDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=db_vendas;Username=postgres;Password=Quimica@7295");

            return new VendasDbContext(optionsBuilder.Options);
        }
    }
}
