using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Factories.Interfaces;
using Asia.Solid.Domain.Services;
using Asia.Solid.Domain.Services.Interfaces;
using System;

namespace Asia.Solid.Domain.Factories
{
    public class CalculoImpostoTipoProdutoFactory : ICalculoImpostoTipoProdutoFactory
    {
        public ICalculoImpostoService GetCalculoImpostoTipoProduto(TipoProduto tipoProduto)
        {
            ICalculoImpostoService calculoImpostoTipoProduto;

            switch (tipoProduto)
            {
                case TipoProduto.Alimentos:
                    calculoImpostoTipoProduto = new CalculoImpostoAlimentosService();
                    break;
                case TipoProduto.Eletronico:
                    calculoImpostoTipoProduto = new CalculoImpostoEletronicoService();
                    break;
                case TipoProduto.Superfulos:
                    calculoImpostoTipoProduto = new CalculoImpostoSuperfulosService();
                    break;
                default:
                    throw new ArgumentException("O tipo de produto informado não está disponível.");
            }
            return calculoImpostoTipoProduto;
        }
    }
}
