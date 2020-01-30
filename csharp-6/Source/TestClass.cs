using Codenation.Challenge;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    public class TestClass
    {
        [Add]
        private decimal primeiroValor;

        [Add]
        private decimal segundoValor;

        [Add]
        private decimal terceiroValor;

        [Subtract]
        private decimal quartoValor;

        [Subtract]
        private decimal quintoValor;

        [Subtract]
        private decimal sextoValor;

        public TestClass()
        {
        }

        public decimal GetPrimeiroValor()
        {
            return primeiroValor;
        }

        public void SetPrimeiroValor(decimal valor)
        {
            primeiroValor = valor;
        }

        public decimal GetSegundoValor()
        {
            return segundoValor;
        }

        public void SetSegundoValor(decimal valor)
        {
            segundoValor = valor;
        }

        public decimal GetTerceiroValor()
        {
            return terceiroValor;
        }

        public void SetTerceiroValor(decimal valor)
        {
            terceiroValor = valor;
        }

        public decimal GetQuartoValor()
        {
            return quartoValor;
        }

        public void SetQuartoValor(decimal valor)
        {
            quartoValor = valor;
        }

        public decimal GetQuintoValor()
        {
            return quintoValor;
        }

        public void SetQuintoValor(decimal valor)
        {
            quintoValor = valor;
        }

        public decimal GetSextoValor()
        {
            return sextoValor;
        }

        public void SetSextoValor(decimal valor)
        {
            sextoValor = valor;
        }

    }
}
