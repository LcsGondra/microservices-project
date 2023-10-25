using Models.Banco;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Banco
{
    public class AutorizarCompra
    {
        [Fact]
        public void Inativo()
        {
            var cartao = new Cartao
            {
                LimiteAtual = 2000.00,
                LimiteMax = 2000.00,
                Ativo = false,
                compras = new List<Compra>()
            };
            Assert.Equal("RECUSADA", cartao.AutorizarCompra(500, DateTime.Now, "lojas americanas").Status);
        }
    }
}
