namespace Asia.Solid.Domain.Entities
{
    public class ProdutoEletronico : Produto
    {
        public ProdutoEletronico()
        {
            ValorImposto = 0.15M;
            TipoProduto = TipoProduto.Eletronico;
        }
    }
}