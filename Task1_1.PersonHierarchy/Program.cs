using Task1_1.PersonHierarchy;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("--- Створення Person ---");
var person = new Person("Андрій", 28);

Console.WriteLine("\n--- Створення Employee ---");
var employee = new Employee("Максим", 32, "EPAM", 65000m);

Console.WriteLine("\n--- Створення Manager ---");
var manager = new Manager("Олена", 35, "SoftServe", 95000m, "Розробка", 12);

Console.WriteLine("\n--- Інформація для кожного типу ---");
person.DisplayInfo();
Console.WriteLine();
employee.DisplayInfo();
Console.WriteLine();
manager.DisplayInfo();

Console.WriteLine("\n--- Поліморфізм: Manager IS-A Person ---");
Person p = manager;
p.DisplayInfo(); // Викличе Manager.DisplayInfo()

namespace Task1_1.PersonHierarchy
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine($"  Person конструктор: {Name}");
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Ім'я: {Name}, Вік: {Age}");
        }
    }

    public class Employee : Person
    {
        public string Company { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, int age, string company, decimal salary)
            : base(name, age)
        {
            Company = company;
            Salary = salary;
            Console.WriteLine($"  Employee конструктор: {company}");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  Компанія: {Company}, Зарплата: {Salary:F2} грн");
        }
    }

    public class Manager : Employee
    {
        public string Department { get; set; }
        public int SubordinatesCount { get; set; }

        public Manager(string name, int age, string company, decimal salary,
                       string department, int subordinatesCount)
            : base(name, age, company, salary)
        {
            Department = department;
            SubordinatesCount = subordinatesCount;
            Console.WriteLine($"  Manager конструктор: {department}");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  Відділ: {Department}, Підлеглих: {SubordinatesCount}");
        }
    }
}