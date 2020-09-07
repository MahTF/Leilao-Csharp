using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComApenasUmLance()
        {
            //Arrange - cenário (Primeiro A)
            var leilao = new Leilao("Van Gogh");
            var joao = new Interessada("João", leilao);

            leilao.RecebeLance(joao, 500);

            //Act - Método sob teste (Segundo A)
            leilao.TerminaPregao();

            //Assert - Resultado esperado (Terceiro A)
            var valorEsperado = 500;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComVariosLances()
        {
            //Arrange - cenário (Primeiro A)
            var leilao = new Leilao("Van Gogh");
            var joao = new Interessada("João", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(joao, 500);
            leilao.RecebeLance(maria, 600);
            leilao.RecebeLance(joao, 700);
            leilao.RecebeLance(maria, 650);

            //Act - Método sob teste (Segundo A)
            leilao.TerminaPregao();

            //Assert - Resultado esperado (Terceiro A)
            var valorEsperado = 700;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
