namespace Asia.Solid.Domain.Entities
{
    public abstract class Produto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorImposto { get; set; }
        public decimal ValorCalculado { get; set; }
        public TipoProduto TipoProduto { get; set; }

        public virtual void CalcularValorTotal()
        {
            ValorCalculado = (Valor + (Valor * ValorImposto)) * Quantidade;
        }
    }
}