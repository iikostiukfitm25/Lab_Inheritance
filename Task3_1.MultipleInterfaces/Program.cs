using Task3_1.MultipleInterfaces;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Duck duck = new Duck("Дональд", "Качка");
Penguin penguin = new Penguin("Ковальскі", "Пінгвін");
Eagle eagle = new Eagle("Беркут", "Орел");
Superhero hero = new Superhero("Супертварина", "Невідомий");

Console.WriteLine("=== Поліморфізм через інтерфейс ISwimmable ===");
List<ISwimmable> swimmers = [duck, penguin, hero];
foreach (ISwimmable s in swimmers)
    s.Swim();

Console.WriteLine("\n=== Поліморфізм через інтерфейс IFlyable ===");
List<IFlyable> flyers = [duck, eagle, hero];
foreach (IFlyable f in flyers)
    f.Fly();

Console.WriteLine("\n=== Перевірка реалізації інтерфейсу (is) ===");
Animal[] animals = [duck, penguin, eagle, hero];
foreach (Animal a in animals)
{
    Console.Write($"{a.Name}: ");
    if (a is ISwimmable) Console.Write("плаває ");
    if (a is IFlyable) Console.Write("літає ");
    if (a is IRunnable) Console.Write("бігає ");
    Console.WriteLine();
}

namespace Task3_1.MultipleInterfaces
{
    public interface ISwimmable
    {
        void Swim();
        double MaxSwimSpeed { get; }
    }

    public interface IFlyable
    {
        void Fly();
        double MaxAltitude { get; }
    }

    public interface IRunnable
    {
        void Run();
        double MaxRunSpeed { get; }
    }

    public class Animal
    {
        public string Name { get; set; }
        public string Species { get; set; }

        public Animal(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public virtual void Eat() => Console.WriteLine($"{Name} ({Species}) їсть");
        public override string ToString() => $"{Name} ({Species})";
    }

    public class Duck : Animal, ISwimmable, IFlyable
    {
        public double MaxSwimSpeed => 8.5;
        public double MaxAltitude => 300.0;

        public Duck(string name, string species) : base(name, species) { }

        public void Swim() => Console.WriteLine($"{Name} пливе по озеру ({MaxSwimSpeed} км/год)");
        public void Fly() => Console.WriteLine($"{Name} летить на висоті до {MaxAltitude} м");
    }

    public class Penguin : Animal, ISwimmable, IRunnable
    {
        public double MaxSwimSpeed => 35.0;
        public double MaxRunSpeed => 6.0;

        public Penguin(string name, string species) : base(name, species) { }

        public void Swim() => Console.WriteLine($"{Name} стрімко пірнає ({MaxSwimSpeed} км/год)");
        public void Run() => Console.WriteLine($"{Name} біжить по кризі ({MaxRunSpeed} км/год)");
    }

    public class Eagle : Animal, IFlyable, IRunnable
    {
        public double MaxAltitude => 4500.0;
        public double MaxRunSpeed => 15.0;

        public Eagle(string name, string species) : base(name, species) { }

        public void Fly() => Console.WriteLine($"{Name} ширяє високо в горах ({MaxAltitude} м)");
        public void Run() => Console.WriteLine($"{Name} розбігається перед зльотом ({MaxRunSpeed} км/год)");
    }

    public class Superhero : Animal, ISwimmable, IFlyable, IRunnable
    {
        public double MaxSwimSpeed => 80.0;
        public double MaxAltitude => 10000.0;
        public double MaxRunSpeed => 120.0;

        public Superhero(string name, string species) : base(name, species) { }

        public void Swim() => Console.WriteLine($"{Name} розсікає океан ({MaxSwimSpeed} км/год)");
        public void Fly() => Console.WriteLine($"{Name} летить у стратосфері ({MaxAltitude} м)");
        public void Run() => Console.WriteLine($"{Name} мчить зі швидкістю {MaxRunSpeed} км/год");
    }
}