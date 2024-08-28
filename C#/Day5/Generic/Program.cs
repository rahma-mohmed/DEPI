namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GenericList<int> list1 = new GenericList<int>();
            list1.Add(1);
            list1.Add(2);
            //list1.Display();
            Console.WriteLine(list1.GetByIndex(2));
        }
    }
}
