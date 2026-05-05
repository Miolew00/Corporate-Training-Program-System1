using System.Collections.Generic;

namespace Corporate_Training_Program_System.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Specialization { get; set; } = null!;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
