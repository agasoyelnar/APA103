using System;
namespace _04_AccessModifiresEncupsulationNamespace.Models
{
	public class Car
	{
		public string  _name;
		private int _hoursePower;

		public int HoursePower
		{
			get
			{
				if (_hoursePower < 100)
				{
					Console.WriteLine("olmaz") ;
				}
				Console.WriteLine("olar");
				return -1;
			}
			set
			{
				if (value < 100)
				{ Console.WriteLine("sehv"); }
				_hoursePower = value;

            }
		}

	}

}

