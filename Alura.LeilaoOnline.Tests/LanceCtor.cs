using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExDadoValorNegativo()
        {
            var valorNegativo = -100;

            var exObtida = Assert.Throws<ArgumentException>(() => new Lance(null, valorNegativo));

            var msgEsperada = "Valor do Lance deve ser igual ou maior que 0!";
            Assert.Equal(msgEsperada, exObtida.Message);
        }
    }
}
