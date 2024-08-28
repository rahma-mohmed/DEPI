using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var studentService = new StudentService();

        while (true)
        {
            Console.WriteLine("\nStudent Management System");
            Console.WriteLine("1. Display Students");
            Console.WriteLine("2. Insert Student");
            Console.WriteLine("3. Edit Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Display Student Age");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    studentService.DisplayStudents();
                    break;
                case "2":
                    studentService.InsertStudent();
                    break;
                case "3":
                    studentService.EditStudent();
                    break;
                case "4":
                    studentService.DeleteStudent();
                    break;
                case "5":
                    studentService.DisplayStudentAge();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
