using System;
namespace _06_InterfaceAbstraction.Interface
{
    public class Calculation : ICalculation
    {
        public double Calculate(double a, double b, string operation)
        {
            if (operation == "+")
                return a + b;

            else if (operation == "-")
                return a - b;

            else if (operation == "*")
                return a * b;

            else if (operation == "/")
            {
                if (b != 0)
                    return a / b;
                else
                {
                    Console.WriteLine("0-a bölmək olmaz!");
                    return 0;
                }
            }

            else
            {
                Console.WriteLine("Yanlış əməl!");
                return 0;
            }
        }
    }
}
