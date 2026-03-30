using System;
using _07_NullableEnumStruct.Enum;
namespace _07_NullableEnumStruct.Models;

public class DrinkOrder
{
    public int OrderNumber { get; set; }
    public string CustomerName { get; set; }
    public DrinkType Drink { get; set; }
    public DrinkSize Size { get; set; }
    public OrderStatus Status { get; set; }
    public decimal Price { get; set; }

    public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
    {
        OrderNumber = orderNumber;
        CustomerName = customerName;
        Drink = drink;
        Size = size;
        Status = OrderStatus.New;
        Price = CalculatePrice();
    }

    public decimal CalculatePrice()
    {
        switch (Drink)
        {
            case DrinkType.Coffee:
                if (Size == DrinkSize.Small) return 3;
                if (Size == DrinkSize.Medium) return 4;
                if (Size == DrinkSize.Large) return 5;
                break;
            case DrinkType.Tea:
                if (Size == DrinkSize.Small) return 2;
                if (Size == DrinkSize.Medium) return 3;
                if (Size == DrinkSize.Large) return 4;
                break;

            case DrinkType.Juice:
                if (Size == DrinkSize.Small) return 4;
                if (Size == DrinkSize.Medium) return 5;
                if (Size == DrinkSize.Large) return 6;
                break;

            case DrinkType.Water:
                if (Size == DrinkSize.Small) return 1;
                if (Size == DrinkSize.Medium) return 1.5m;
                if (Size == DrinkSize.Large) return 2;
                break;
        }
                return 0;
    }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Sifaris #{OrderNumber} statusu: {newStatus}");
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"Sifaris #{OrderNumber}");
            Console.WriteLine($"Musteri: {CustomerName}");
            Console.WriteLine($"İçki: {Drink}");
            Console.WriteLine($"olcu: {Size}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Qiymet: {Price}");
            Console.WriteLine("-------------------");
        }
    }

