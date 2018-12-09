namespace Asia.Solid.Domain.Entities
{
    public class PagamentoNaoRealizado : Pagamento
    {
        public PagamentoNaoRealizado(Carrinho carrinho)
        {
            _carrinho = carrinho;
        }

        public override Carrinho EfetuarPagamento()
        {
            _carrinho.InformarNaoPagamento();

            return _carrinho;
        }
    }
}