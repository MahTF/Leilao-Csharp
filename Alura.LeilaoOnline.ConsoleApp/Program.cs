using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            LeilaoComApenasUmLance();
            LeilaoComVariosLances();
        }

        private static void Verificar(double esperado, double obtido)
        {
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste OK!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste Falhou! Esperado: {esperado}, obtido: {obtido}");
                Console.ResetColor();
            }
        }

        private static void LeilaoComApenasUmLance()
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

            Verificar(valorEsperado, valorObtido);
        }

        private static void LeilaoComVariosLances()
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

            Verificar(valorEsperado, valorObtido);
        }
    }
}
