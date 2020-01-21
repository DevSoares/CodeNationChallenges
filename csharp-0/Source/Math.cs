using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            bool whileLock = true;
            List<int> fibonacciList = new List<int>
            {
                0,
                1
            };

            do
            {
                int lastValue = fibonacciList.LastOrDefault();
                int antepenultimateValue = fibonacciList[fibonacciList.LastIndexOf(lastValue) - 1];

                if (lastValue + antepenultimateValue >= 350)
                    whileLock = false;
                else
                    fibonacciList.Add(lastValue + antepenultimateValue);

            } while (whileLock);

            return fibonacciList;
        }

        public bool IsFibonacci(int numberToTest)
        {
            List<int> fibonacciList = Fibonacci();
            bool isFibonacci = fibonacciList.Any(fl => fl.Equals(numberToTest));

            return isFibonacci;
        }
    }
}
