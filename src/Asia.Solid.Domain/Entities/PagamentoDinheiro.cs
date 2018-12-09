namespace Asia.Solid.Domain.Entities
{
    public class PagamentoDinheiro : Pagamento
    {
        public PagamentoDinheiro(Carrinho carrinho)
        {
            _carrinho = carrinho;
            FormaPagamento = FormaPagamento.Dinheiro;
        }
    }
}