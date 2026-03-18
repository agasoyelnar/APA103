namespace TransportApp
{
    public class Truck : Vehicle
    {
        public double CargoCapacity;
        public int AxleCount;
        public double CurrentLoad;
        public int MaxSpeed;

        public Truck(string brand, string model, int year, string plate,
            double capacity, int axle, double load, int maxSpeed)
            : base(brand, model, year, plate)
        {
            CargoCapacity = capacity;
            AxleCount = axle;
            CurrentLoad = load;
            MaxSpeed = maxSpeed;
        }

        public void ShowTruckInfo()
        {
            ShowBasicInfo();
            Console.WriteLine("Capacity: " + CargoCapacity);
            Console.WriteLine("Load: " + CurrentLoad);
            Console.WriteLine("Axle: " + AxleCount);
            Console.WriteLine("MaxSpeed: " + MaxSpeed);
        }

        public void LoadCargo(double weight)
        {
            if (CurrentLoad + weight <= CargoCapacity)
            {
                CurrentLoad += weight;
                Console.WriteLine("Yuk elave olundu");
            }
            else
            {
                Console.WriteLine("Yuk artiqdir!");
            }
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * (25 + CurrentLoad * 2) * 1.80;
        }
    }
}

