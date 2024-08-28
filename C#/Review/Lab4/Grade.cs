namespace Lab4
{
    public class Grade
    {
        public string Subject { get; set; }
        public int Score { get; set; }

        // Validate the grade data
        public void Validate()
        {
            if (string.IsNullOrEmpty(Subject))
            {
                throw new ArgumentNullException("Subject cannot be empty");
            }

            if (Score < 0 || Score > 100)
            {
                throw new ArgumentOutOfRangeException("Score must be between 0 and 100");
            }
        }

        public void AddGradeToStudent(Student student, Grade grade)
        {
            try
            {
                grade.Validate();
                student.Grades.Add(grade);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
