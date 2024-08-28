namespace Lab4
{
    public class Teacher
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public void AddStudent(Student student)
        {
            if (student != null && !Students.Contains(student))
            {
                Students.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            if (student != null && Students.Contains(student))
            {
                Students.Remove(student);
            }
        }
    }
}
