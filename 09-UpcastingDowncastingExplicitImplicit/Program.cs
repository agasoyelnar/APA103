using System;
using UpCasting_DownCasting.Models;
namespace _09_UpcastingDowncastingExplicitImplicit.Exchange
{
    internal class Proqram
    {
        static void Main()
        {
            #region UpCastingDownCasting
            //    Dog dog = new Dog { AvgLifeTime = 13, Breed = "Kanqal", Gender = "male", Name = "hatiko" };
            //    Eagle eagle = new Eagle { AvgLifeTime = 300, FlySpeed = 100, Gender = "female" };

            //    //UpCasting
            //    //Animal animal = dog;
            //    //Animal animal1 = eagle;
            //    //downcasting
            //    //Dog dog1 = (Dog)animal;
            //    //Eagle eagle1 = (Eagle)animal;

            //    Animal[] animals = { dog, eagle };
            //    foreach (var animal in animals)
            //    {
            //        Eagle eagle1 = animal as Eagle;
            //        //eagle1.Fly();

            //        //if (eagle1 != null)
            //        //{
            //        //    eagle1.Fly();
            //        //}
            //        if (animal is Eagle)
            //        {
            //            Eagle eagle2 = (Eagle)animal;
            //        }
            //    }
            #endregion

            #region boxing
            ////boxing
            //int a = 5;
            //Object b = a;

            ////unboxing
            //string c = b as string;

            //Test test = new Test();

            //ITest Itest = test;
            #endregion

            Dollar dollar = new(200);

            Manat manat = new(170);

            Dollar dollar1 = (Dollar)manat;
            Console.WriteLine(dollar1.USD);

            Manat manat1 = dollar;
            Console.WriteLine(manat.AZN);

        }


        public struct Test : ITest
        {
            public int x { get; set; }
            public void Y()
            {
                throw new NotImplementedException();
            }
        }

        public interface ITest
        {
            void Y(); 
        }
    }
}