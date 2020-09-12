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
            IModalidadeAvaliacao modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var joao = new Interessada("João", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
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
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);

            leilao.IniciaPregao();
            leilao.TerminaPregao();

            var valorEsperado = 0;

            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Fact]
        public void LancaInvalidExDadoPregaoNaoIniciado()
        {
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);

            //Ao usar o metodo Throws, precisa passar o parametro como Delegate.
            var exObtida = Assert.Throws<InvalidOperationException>(() => leilao.TerminaPregao());
            var msgEsperada = "Não é possível finalizar um leilão que não foi iniciado!";
            Assert.Equal(msgEsperada, exObtida.Message);
        }

        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250 })]
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNaModalidade(double valorDestino, double valorEsperado, double[] ofertas)
        {
            IModalidadeAvaliacao modalidade = new OfertaSuperiorMaisProxima(valorDestino);
            var leilao = new Leilao("Van Gogh", modalidade);
            var joao = new Interessada("João", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i%2) == 0)
                {
                    leilao.RecebeLance(joao, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            leilao.TerminaPregao();

            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }
    }
}
