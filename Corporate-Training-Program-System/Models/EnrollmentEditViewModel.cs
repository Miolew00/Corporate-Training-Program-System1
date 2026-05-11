namespace Corporate_Training_Program_System.Models.ViewModels
{
    public class EnrollmentEditViewModel
    {
        public int EnrollmentId { get; set; }

        public int CourseId { get; set; }
        public int EmployeeId { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public string CompletionStatus { get; set; } = string.Empty;

        public List<Course>? Courses { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
