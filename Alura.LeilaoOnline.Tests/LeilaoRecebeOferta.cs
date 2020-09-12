using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(5, new double[] { 100, 500, 600, 850, 900})]
        [InlineData(2, new double[] { 500, 600})]
        public void NaoPermiteNovosLancesAposFinalizarLeilao(int valorEsperado, double[] ofertas)
        {
            //Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var joao = new Interessada("João", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for(int i = 0; i < ofertas.Length; i++)
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

            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(joao, 700);

            //Assert
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void NaoAceitaLancesMesmoClienteRealizouUltimoLance()
        {
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var joao = new Interessada("João", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(joao, 800);

            //Act
            leilao.RecebeLance(joao, 900);

            leilao.TerminaPregao();

            var valorEsperado = 1;
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
