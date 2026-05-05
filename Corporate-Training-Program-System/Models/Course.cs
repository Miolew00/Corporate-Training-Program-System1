using System.Collections.Generic;

namespace Corporate_Training_Program_System.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Duration { get; set; }

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
