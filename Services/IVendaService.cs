using api_salles_manager.Domain;

namespace api_salles_manager.Services
{
    public interface IVendaService
    {
        Task<Venda?> ObterVendaPorId(Guid id);
        Task CriarVenda(Venda venda);
        Task AtualizarVenda(Guid id, Venda vendaAtualizada);
        Task DeletarVenda(Guid id);
    }
}
