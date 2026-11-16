using Task1_2.ShapesOverrideVsNew;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Circle circle = new Circle(5.0, "червоний");
Shape shapeRef = circle; // Посилання базового типу

Console.WriteLine("=== override (поліморфізм працює) ===");
circle.Draw();          // [Circle] ...
shapeRef.Draw();        // [Circle] ... — override!

Console.WriteLine("\n=== new (поліморфізм НЕ працює) ===");
circle.GetInfo();       // [Circle] ...
shapeRef.GetInfo();     // [Shape] ... — new! Тип змінної визначає метод

Console.WriteLine("\n=== Масив Shape[] з різними фігурами ===");
Shape[] shapes =
[
    new Circle(3.0, "синій"),
    new Rectangle(4.0, 6.0, "зелений"),
    new Circle(2.5, "жовтий")
];

foreach (Shape s in shapes)
{
    s.Draw();
    Console.WriteLine($"  Площа фігури: {s.GetArea():F2}");
}

namespace Task1_2.ShapesOverrideVsNew
{
    public class Shape
    {
        public string Color { get; set; }

        public Shape(string color) => Color = color;

        public virtual double GetArea() => 0;
        public virtual void Draw() => Console.WriteLine($"[Shape] Малюю фігуру ({Color})");
        public void GetInfo() => Console.WriteLine($"[Shape] Це фігура кольору {Color}");
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius, string color) : base(color) => Radius = radius;

        public override double GetArea() => Math.PI * Radius * Radius;
        public override void Draw() => Console.WriteLine($"[Circle] Малюю коло R={Radius} ({Color})");
        public new void GetInfo() => Console.WriteLine($"[Circle] Це коло R={Radius} ({Color})");
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height, string color) : base(color)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;
        public override void Draw() => Console.WriteLine($"[Rectangle] Малюю прямокутник {Width}x{Height} ({Color})");
        public new void GetInfo() => Console.WriteLine($"[Rectangle] Це прямокутник {Width}x{Height} ({Color})");
    }
}