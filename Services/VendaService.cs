using api_salles_manager.Data.Interfaces;
using api_salles_manager.Domain;

namespace api_salles_manager.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;

        public VendaService(IVendaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Venda?> ObterVendaPorId(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CriarVenda(Venda venda)
        {
            await _repository.AddAsync(venda);
        }

        public async Task AtualizarVenda(Guid id, Venda vendaAtualizada)
        {
            var venda = await _repository.GetByIdAsync(id);
            if (venda == null) throw new KeyNotFoundException("Venda não encontrada.");

            // Atualiza os dados da venda
            venda.Numero = vendaAtualizada.Numero;
            venda.Cliente = vendaAtualizada.Cliente;
            venda.Filial = vendaAtualizada.Filial;
            venda.DataVenda = vendaAtualizada.DataVenda;
            venda.Cancelada = vendaAtualizada.Cancelada;
            venda.Itens = vendaAtualizada.Itens;

            await _repository.UpdateAsync(venda);
        }

        public async Task DeletarVenda(Guid id)
        {
            var venda = await _repository.GetByIdAsync(id);
            if (venda == null) throw new KeyNotFoundException("Venda não encontrada.");
            await _repository.DeleteAsync(venda);
        }
    }
}
