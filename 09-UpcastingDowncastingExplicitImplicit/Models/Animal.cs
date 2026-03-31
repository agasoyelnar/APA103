using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpCasting_DownCasting.Models
{
    internal abstract class Animal
    {
        public int AvgLifeTime { get; set; }
        public string Gender { get; set; }

        public virtual void Eat()
        {
            Console.WriteLine("Qidalanir");
        }
    }
}


