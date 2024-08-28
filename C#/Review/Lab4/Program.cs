using System.Diagnostics;

namespace Lab4
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher { Name = "Mr. Smith" };

            teacher.AddStudent(new Student { Name = "Alice" });
            teacher.AddStudent(new Student { Name = "Bob" });
            teacher.AddStudent(new Student { Name = "Charlie" });

            teacher.Students.Sort();

            foreach (var student in teacher.Students)
            {
                Console.WriteLine(student.Name); 
            }
        }
    }
}
