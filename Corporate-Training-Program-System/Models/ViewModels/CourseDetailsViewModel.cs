namespace Corporate_Training_Program_System.Models.ViewModels
{
    public class CourseDetailsViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string TrainerName { get; set; } = string.Empty;

        public List<EnrollmentItemViewModel> Enrollments { get; set; } = new();
    }
}
