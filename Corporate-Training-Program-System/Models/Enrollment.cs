namespace Corporate_Training_Program_System.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public DateTime EnrolledOn { get; set; } = DateTime.Now;
    }
}
