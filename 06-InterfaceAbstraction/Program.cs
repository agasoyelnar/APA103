using System;
namespace _06_InterfaceAbstraction.Interface
{
    class Program
    {
        static void Main()
        {
            Calculation calc = new Calculation();

            Console.Write("1-ci ededi daxil et: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("2-ci ededi daxil et: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("emeli daxil et (+, -, *, /): ");
            string emel = Console.ReadLine();

            double result = calc.Calculate(a, b, emel);

            Console.WriteLine("Nəticə: " + result);
        }
    }
}
