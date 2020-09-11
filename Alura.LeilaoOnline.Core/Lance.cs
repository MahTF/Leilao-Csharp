using System;

namespace Alura.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor do Lance deve ser igual ou maior que 0!");
            }
            Cliente = cliente;
            Valor = valor;
        }
    }
}
