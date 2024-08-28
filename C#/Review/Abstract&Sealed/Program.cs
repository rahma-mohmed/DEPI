namespace Abstract_Sealed
{
    public abstract class Animal
    {
        public abstract void MakeSound();

        public void Sleep()
        {
            Console.WriteLine("The animal is sleeping.");
        }
    }

    public sealed class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("The cat meows.");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("The dog barks.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
