namespace Corporate_Training_Program_System.Models.ViewModels
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string TrainerName { get; set; } = null!;
        public int Duration { get; set; }
    }
}
