namespace TransportApp
{
    public class Car : Vehicle
    {
        public int DoorsCount;
        public int TrunkCapacity;
        public bool IsAutomatic;
        public int MaxSpeed;

        public Car(string brand, string model, int year, string plate,
            int doors, int trunk, bool isAuto, int maxSpeed)
            : base(brand, model, year, plate)
        {
            DoorsCount = doors;
            TrunkCapacity = trunk;
            IsAutomatic = isAuto;
            MaxSpeed = maxSpeed;
        }

        public void ShowCarInfo()
        {
            ShowBasicInfo();
            Console.WriteLine("Doors: " + DoorsCount);
            Console.WriteLine("Trunk: " + TrunkCapacity);
            Console.WriteLine("Automatic: " + IsAutomatic);
            Console.WriteLine("MaxSpeed: " + MaxSpeed);
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 8 * 1.50;
        }
    }
}
