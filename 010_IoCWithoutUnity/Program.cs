﻿using System;

namespace IoCWithoutUnity
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new[] { "10", "+", "20", "-", "30", "+", "1" };
            }

            var container = new Container();
            var calculator = (ICalculator)container.Create("ICalculator");
            int result = calculator.Evaluate(args);

            Console.WriteLine(result);
        }
    }
}
