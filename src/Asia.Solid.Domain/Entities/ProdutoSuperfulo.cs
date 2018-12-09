namespace Asia.Solid.Domain.Entities
{
    public class ProdutoSuperfulo : Produto
    {
        public ProdutoSuperfulo()
        {
            ValorImposto = 0.20M;
            TipoProduto = TipoProduto.Superfulo;
        }
    }
}