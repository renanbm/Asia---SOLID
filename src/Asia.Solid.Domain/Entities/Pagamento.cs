namespace Asia.Solid.Domain.Entities
{
    public abstract class Pagamento
    {
        public Carrinho _carrinho { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        public virtual Carrinho EfetuarPagamento()
        {
            _carrinho.InformarPagamento();

            return _carrinho;
        }
    }
}