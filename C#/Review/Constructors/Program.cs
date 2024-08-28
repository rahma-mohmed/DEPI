namespace Constructors
{

    public class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
            Console.WriteLine("Animal parameterized constructor called.");
        }

        //Default
        public Animal()
        {
            Name = "Unknown";
            Console.WriteLine("Animal default constructor called.");
        }
    }

    public class Dog : Animal
    {
        public string Breed { get; }

        //Create a derived class constructor that calls a default base class constructor implicitly
        //1.Animal's default constructor
        //2.then Dog's constructor.

        public Dog(string breed)
        {
            Breed = breed;
            Console.WriteLine("Dog constructor called (implicit base constructor).");
        }

        public Dog(string name, string breed)
        : base(name)
        {
            Breed = breed;
            Console.WriteLine("Dog constructor called (explicit base constructor).");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Dog instance with implicit base constructor:");
            Dog dog1 = new Dog("Bulldog");
            // Output:
            // Animal default constructor called.
            // Dog constructor called (implicit base constructor).

            Console.WriteLine("\nCreating Dog instance with explicit base constructor:");
            Dog dog2 = new Dog("Max", "Beagle");
            // Output:
            // Animal parameterized constructor called.
            // Dog constructor called (explicit base constructor).
        }
    }
}
