namespace api_salles_manager.Domain
{
    public class ItemVenda
    {
        public Guid Id { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal => (ValorUnitario * Quantidade) - Desconto;
    }
}
