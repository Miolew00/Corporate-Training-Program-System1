using System.ComponentModel.DataAnnotations;

namespace Corporate_Training_Program_System.Models.ViewModels
{
    public class CourseEditViewModel
    {
        public int CourseId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = null!;

        [Required, StringLength(1000)]
        public string Description { get; set; } = null!;

        [Range(1, 200, ErrorMessage = "Продължителността трябва да е между 1 и 200 часа.")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Trainer")]
        public int TrainerId { get; set; }
    }
}
