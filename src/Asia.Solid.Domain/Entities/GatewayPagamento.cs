﻿using System;

namespace Asia.Solid.Domain.Entities
{
    public class GatewayPagamento : IDisposable
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NomeImpresso { get; set; }
        public decimal Valor { get; set; }
        public int MesExpiracao { get; set; }
        public int AnoExpiracao { get; set; }
        public FormaPagamentoCartao FormaPagamentoCartao { get; set; }

        public void Dispose()
        {
            Login = string.Empty;
            Senha = string.Empty;
            NomeImpresso = string.Empty;
            Valor = 0M;
            MesExpiracao = 0;
            AnoExpiracao = 0;
        }
    }
}
