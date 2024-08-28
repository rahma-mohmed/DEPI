namespace Virtual
{
    public class Animal
    {
        protected virtual string Name { get; set; }

        public virtual void MakeSound()
        {
            Console.WriteLine("Some generic animal sound.");
        }
    }

    public class Dog : Animal
    {
        protected override string Name { get; set; } = "Dog";

        public override void MakeSound()
        {
            Console.WriteLine("The dog barks.");
        }
    }

    public class Beagle : Dog
    {
        public sealed override void MakeSound()
        {
            Console.WriteLine("The beagle barks softly.");
        }
    }

    public class SuperBeagle : Beagle
    {
        /*public override void MakeSound()
        {
                compile time error
        }*/
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
