public class StudentService
{
    private List<Student> students = new List<Student>();
    private int nextId = 1;

    public StudentService()
    {
        // Sample data
        students.Add(new Student { Id = nextId++, Name = "Alice", DateOfBirth = new DateTime(2000, 5, 15) });
        students.Add(new Student { Id = nextId++, Name = "Bob", DateOfBirth = new DateTime(1999, 8, 22) });
    }

    public void DisplayStudents()
    {
        Console.WriteLine("\nStudent List:");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }

    public void InsertStudent()
    {
        var name = GetValidString("Enter student name: ");
        var dob = GetValidDate("Enter date of birth (yyyy-mm-dd): ");

        if (dob != null)
        {
            students.Add(new Student { Id = nextId++, Name = name, DateOfBirth = dob.Value });
            Console.WriteLine("Student added successfully.");
        }
    }

    public void EditStudent()
    {
        var id = GetValidInt("Enter student ID to edit: ");
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student != null)
        {
            student.Name = GetValidString("Enter new name: ");
            var dob = GetValidDate("Enter new date of birth (yyyy-mm-dd): ");

            if (dob != null)
            {
                student.DateOfBirth = dob.Value;
                Console.WriteLine("Student details updated successfully.");
            }
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public void DeleteStudent()
    {
        var id = GetValidInt("Enter student ID to delete: ");
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public void DisplayStudentAge()
    {
        var id = GetValidInt("Enter student ID to display age: ");
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student != null)
        {
            Console.WriteLine($"Student's age: {student.GetAge()}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    private string GetValidString(string prompt)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? "Unknown" : input;
    }

    private DateTime? GetValidDate(string prompt)
    {
        Console.Write(prompt);
        if (DateTime.TryParse(Console.ReadLine(), out var dob))
        {
            return dob;
        }
        else
        {
            Console.WriteLine("Invalid date format.");
            return null;
        }
    }

    private int GetValidInt(string prompt)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out var id))
        {
            return id;
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
            return -1; // Return an invalid ID
        }
    }
}
