using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(750, new double[] { 500, 600, 625, 650, 700, 750 })]
        [InlineData(750, new double[] { 500, 600, 625, 700, 630, 750 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorLances(double valorEsperado, double[] ofertas)
        {
            //Arrange - cenário (Primeiro A)
            var leilao = new Leilao("Van Gogh");
            var joao = new Interessada("João", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if((i%2) == 0)
                {
                    leilao.RecebeLance(joao, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            //Act - Método sob teste (Segundo A)
            leilao.TerminaPregao();

            //Assert - Resultado esperado (Terceiro A)
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void RetornaZeroNoLeilaoSemLances()
        {
            var leilao = new Leilao("Van Gogh");

            leilao.TerminaPregao();

            var valorEsperado = 0;

            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }
    }
}
