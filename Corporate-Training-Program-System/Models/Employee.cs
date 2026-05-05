using System.Collections.Generic;

namespace Corporate_Training_Program_System.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Department { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
