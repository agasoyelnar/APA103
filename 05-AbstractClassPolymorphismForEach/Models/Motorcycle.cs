namespace TransportApp
{
    public class Motorcycle : Vehicle
    {
        public int EngineCapacity;
        public bool HasSidecar;
        public int MaxSpeed;
        public string Type;

        public Motorcycle(string brand, string model, int year, string plate,
            int engine, bool sidecar, int maxSpeed, string type)
            : base(brand, model, year, plate)
        {
            EngineCapacity = engine;
            HasSidecar = sidecar;
            MaxSpeed = maxSpeed;
            Type = type;
        }

        public void ShowMotorcycleInfo()
        {
            ShowBasicInfo();
            Console.WriteLine("Engine: " + EngineCapacity);
            Console.WriteLine("Sidecar: " + HasSidecar);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("MaxSpeed: " + MaxSpeed);
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 4 * 1.50;
        }
    }
}

