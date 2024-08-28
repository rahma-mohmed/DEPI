namespace Lab4
{
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();

        public int CompareTo(Student other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
