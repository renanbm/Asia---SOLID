namespace Asia.Solid.Domain.Entities
{
    public class ProdutoAlimento : Produto
    {
        public ProdutoAlimento()
        {
            ValorImposto = 0.05M;
            TipoProduto = TipoProduto.Alimento;
        }
    }
}