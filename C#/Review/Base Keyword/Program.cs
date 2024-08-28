namespace Base_Keyword
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(string name , int age)
        {
            Name = name;
            Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    public class Student : Person
    {
        public string School;

        //Explicitly Calling a Specific Base Class Constructor
        public Student(string name, int age, string school) : base(name, age)
        {
            School = school;
            Name = name;
            Age = age;
        }

        public void DisplayStudentInfo()
        {
            base.DisplayInfo();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Alice", 20, "Springfield High");

            student.DisplayStudentInfo();
        }
    }
}
