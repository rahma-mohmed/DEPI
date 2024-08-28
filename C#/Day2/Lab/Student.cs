public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }

    public int GetAge()
    {
        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Year;
        if (DateOfBirth > today.AddYears(-age)) age--;
        return age;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Date of Birth: {DateOfBirth.ToShortDateString()}, Age: {GetAge()}";
    }
}
