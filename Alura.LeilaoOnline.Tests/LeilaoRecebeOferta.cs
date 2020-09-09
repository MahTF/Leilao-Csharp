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
        [InlineData(4, new double[] { 100, 500, 600, 850})]
        [InlineData(2, new double[] { 500, 600})]
        public void NaoPermiteNovosLancesAposFinalizarLeilao(int valorEsperado, double[] ofertas)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var joao = new Interessada("João", leilao);
            leilao.IniciaPregao();

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(joao, valor);
            }
            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(joao, 700);

            //Assert
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
