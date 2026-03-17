using System;
using System.Reflection;
using _04_AccessModifiresEncupsulationNamespace.Models;


internal class Proqram
{
    static void Main()
    {

        //Car car = new Car();
        //Person person = new Person();
        ////typeof(Person).GetField("name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(person, "APA103");
        //var newName = typeof(Person).GetField("name", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(person);

        //Console.WriteLine(newName);

        Car car = new Car();
        car.HoursePower = 50;
        Console.WriteLine(car.HoursePower);

    }
}