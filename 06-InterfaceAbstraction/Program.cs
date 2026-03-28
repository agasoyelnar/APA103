using System;
namespace _06_InterfaceAbstraction.Interface
{
    class Program
    {
        static void Main()
        {
            Calculation calc = new Calculation();

            Console.Write("1-ci ədədi daxil et: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("2-ci ədədi daxil et: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Əməli daxil et (+, -, *, /): ");
            string op = Console.ReadLine();

            double result = calc.Calculate(a, b, op);

            Console.WriteLine("Nəticə: " + result);
        }
    }
}
