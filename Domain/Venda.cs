namespace api_salles_manager.Domain
{
    public class Venda
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public DateTime DataVenda { get; set; }
        public string Cliente { get; set; } // External Identity
        public decimal ValorTotal { get; set; }
        public string Filial { get; set; }
        public List<ItemVenda> Itens { get; set; } = new();
        public bool Cancelada { get; set; }
    }
}
