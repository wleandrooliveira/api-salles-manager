using api_salles_manager.Domain;

namespace api_salles_manager.Data.Interfaces
{
    public interface IVendaRepository
    {
        Task<Venda?> GetByIdAsync(Guid id);
        Task AddAsync(Venda venda);
        Task UpdateAsync(Venda venda);
        Task DeleteAsync(Venda venda);
    }
}
