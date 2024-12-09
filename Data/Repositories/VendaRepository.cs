using api_salles_manager.Data.Interfaces;
using api_salles_manager.Domain;
using Microsoft.EntityFrameworkCore;

namespace api_salles_manager.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly VendasDbContext _context;

        public VendaRepository(VendasDbContext context)
        {
            _context = context;
        }

        public async Task<Venda?> GetByIdAsync(Guid id)
        {
            return await _context.Vendas.Include(v => v.Itens).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Venda venda)
        {
            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Venda venda)
        {
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Venda venda)
        {
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
        }
    }
}
