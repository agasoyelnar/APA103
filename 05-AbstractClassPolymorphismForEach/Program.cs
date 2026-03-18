using System;
using TransportApp;

class Program
{
    static void Main()
    { 
        Car c1 = new Car("Mercedes", "E200", 2023, "10-AA-001", 4, 500, true, 220);
        Car c2 = new Car("BMW", "320i", 2022, "10-AA-002", 4, 480, true, 235);
        Car c3 = new Car("Toyota", "Camry", 2021, "10-AA-003", 4, 524, true, 210);

        Motorcycle m1 = new Motorcycle("Yamaha", "R1", 2023, "10-BB-001", 998, false, 299, "Sport");
        Motorcycle m2 = new Motorcycle("Harley", "Davidson", 2022, "10-BB-002", 1868, true, 180, "Cruiser");

        Truck t1 = new Truck("MAN", "TGX", 2020, "10-CC-001", 18, 3, 12, 120);
        Truck t2 = new Truck("Volvo", "FH16", 2021, "10-CC-002", 25, 4, 18, 110);

        c1.ShowCarInfo();
        Console.WriteLine("Fuel: " + c1.CalculateFuelCost(500));

        m1.ShowMotorcycleInfo();
        Console.WriteLine("Fuel: " + m1.CalculateFuelCost(300));

        t1.ShowTruckInfo();
        Console.WriteLine("Fuel: " + t1.CalculateFuelCost(800));

        t1.LoadCargo(5);
        Console.WriteLine("New Fuel: " + t1.CalculateFuelCost(800));

        int umumi  = 7;

        double ortasuret = (c1.MaxSpeed + c2.MaxSpeed + c3.MaxSpeed +
                          m1.MaxSpeed + m2.MaxSpeed +
                          t1.MaxSpeed + t2.MaxSpeed) / umumi ;

        Console.WriteLine("umumi: " + umumi);
        Console.WriteLine("Orta suret: " + ortasuret);
    }
}