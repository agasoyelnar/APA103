using System;
using _07_NullableEnumStruct.Models;
using _07_NullableEnumStruct.Enum;

class Program
{
    static void Main()
    {
        DrinkOrder order1 = new DrinkOrder(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
        order1.DisplayOrder();

        order1.UpdateStatus(OrderStatus.Preparing);
        order1.UpdateStatus(OrderStatus.Ready);
        order1.UpdateStatus(OrderStatus.Delivered);

        Console.WriteLine("----------------");

        DrinkOrder order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
        order2.DisplayOrder();
        order2.UpdateStatus(OrderStatus.Ready);

        Console.WriteLine("----------------");
        DrinkOrder order3 = new DrinkOrder(103, "Vüqar", DrinkType.Juice, DrinkSize.Small);
        order3.DisplayOrder();

        Console.WriteLine("----------------");

        Console.WriteLine("Qiymetler:");
        Console.WriteLine(order1.Price);
        Console.WriteLine(order2.Price);
        Console.WriteLine(order3.Price);

        decimal umumi = order1.Price + order2.Price + order3.Price;
        Console.WriteLine("umumi: " + umumi);

        Console.WriteLine(DrinkType.Coffee.ToString());
        Console.WriteLine(DrinkSize.Large.ToString());

        DrinkType d = (DrinkType)Enum.Parse(typeof(DrinkType), "Tea");
        DrinkSize s = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");

        Console.WriteLine(d);
        Console.WriteLine(s);

        foreach (var item in Enum.GetValues(typeof(DrinkType)))
        {
            Console.WriteLine(item);
        }
    }
}