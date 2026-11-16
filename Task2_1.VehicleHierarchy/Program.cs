using Task2_1.VehicleHierarchy;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== Порядок конструкторів ===");
var tesla = new ElectricCar("Tesla", "Model 3", 2025, 4, 75);
tesla.ChargeInfo();

Console.WriteLine("\n=== Поліморфізм: масив Vehicle[] ===");
Vehicle[] garage =
[
    new Car("Toyota", "Camry", 2023, 4),
    new Truck("Volvo", "FH16", 2022, 24.5),
    tesla
];

foreach (Vehicle v in garage)
{
    v.DisplayInfo();
    v.Drive(100);
    Console.WriteLine();
}

Console.WriteLine("=== Перевірка типу (is, as) ===");
foreach (Vehicle v in garage)
{
    if (v is Car car)
        Console.WriteLine($"{v.Make} {v.Model} — легковий, дверей: {car.Doors}");

    Truck? truck = v as Truck;
    if (truck is not null)
        Console.WriteLine($"{truck.Make} {truck.Model} — вантажний, макс. вантаж: {truck.MaxLoad} т");
}

namespace Task2_1.VehicleHierarchy
{
    public abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        protected double _fuelLevel;

        protected Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
            _fuelLevel = 100;
            Console.WriteLine($"  [Vehicle] Конструктор: {Make} {Model}");
        }

        ~Vehicle()
        {
            Console.WriteLine($"  [~Vehicle] Фіналізатор: {Make} {Model}");
        }

        public abstract string GetVehicleType();
        public abstract double GetFuelEfficiency();

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[{GetVehicleType()}] {Year} {Make} {Model}");
            Console.WriteLine($"  Паливо/Заряд: {_fuelLevel:F1}%");
            Console.WriteLine($"  Витрата: {GetFuelEfficiency():F1} л/100км");
        }

        public virtual void Drive(double km)
        {
            double consumed = km * GetFuelEfficiency() / 100;
            if (consumed <= _fuelLevel)
            {
                _fuelLevel -= consumed;
                Console.WriteLine($"{Make} {Model} проїхав {km} км. Залишок: {_fuelLevel:F1}%");
            }
            else
            {
                Console.WriteLine("Недостатньо пального!");
            }
        }
    }

    public class Car : Vehicle
    {
        public int Doors { get; set; }

        public Car(string make, string model, int year, int doors) : base(make, model, year)
        {
            Doors = doors;
            Console.WriteLine($"  [Car] Конструктор: {doors} дверей");
        }

        ~Car() => Console.WriteLine($"  [~Car] Фіналізатор: {Make} {Model}");

        public override string GetVehicleType() => "Легковий";
        public override double GetFuelEfficiency() => 7.5;

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  Кількість дверей: {Doors}");
        }
    }

    public class Truck : Vehicle
    {
        public double MaxLoad { get; set; }

        public Truck(string make, string model, int year, double maxLoad) : base(make, model, year)
        {
            MaxLoad = maxLoad;
            Console.WriteLine($"  [Truck] Конструктор: макс. вантаж {maxLoad} т");
        }

        ~Truck() => Console.WriteLine($"  [~Truck] Фіналізатор: {Make} {Model}");

        public override string GetVehicleType() => "Вантажний";
        public override double GetFuelEfficiency() => 18.0;

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  Макс. вантаж: {MaxLoad:F1} т");
        }
    }

    public class ElectricCar : Car
    {
        public int BatteryCapacity { get; set; }

        public ElectricCar(string make, string model, int year, int doors, int batteryCapacity)
            : base(make, model, year, doors)
        {
            BatteryCapacity = batteryCapacity;
            Console.WriteLine($"  [ElectricCar] Конструктор: батарея {batteryCapacity} кВт·год");
        }

        ~ElectricCar() => Console.WriteLine($"  [~ElectricCar] Фіналізатор: {Make} {Model}");

        public override string GetVehicleType() => "Електромобіль";
        public override double GetFuelEfficiency() => 0.0;
        public void ChargeInfo() => Console.WriteLine($"  Ємність батареї {Make} {Model}: {BatteryCapacity} кВт·год");
    }
}