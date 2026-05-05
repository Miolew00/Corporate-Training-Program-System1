using System;
using System.Collections.Generic;

namespace Corporate_Training_Program_System.Models.ViewModels
{
    public class CourseDetailsViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Duration { get; set; }
        public string TrainerName { get; set; } = null!;

        public List<EnrollmentItemViewModel> Enrollments { get; set; } = new();
    }

    public class EnrollmentItemViewModel
    {
        public string EmployeeName { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; }
        public string CompletionStatus { get; set; } = null!;
    }
}
