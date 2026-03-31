using System;
namespace _09_UpcastingDowncastingExplicitImplicit.Exchange
{
	internal class Dollar
	{
		public decimal USD { get; set; }

		public Dollar(decimal usd)
		{
			USD = usd;
		}
        public static explicit operator Dollar(Manat manat)
        {
            return new Dollar(manat.AZN/1.70m);

        }
    }
}

