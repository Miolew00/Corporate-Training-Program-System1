using Corporate_Training_Program_System.Data;
using Corporate_Training_Program_System.Models;
using Corporate_Training_Program_System.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Corporate_Training_Program_System.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Courses
        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses
                .Include(c => c.Trainer)
                .ToListAsync();

            var model = courses.Select(c => new CourseViewModel
            {
                CourseId = c.CourseId,
                Title = c.Title,
                Duration = c.Duration,
                TrainerName = c.Trainer.FirstName + " " + c.Trainer.LastName
            });

            return View(model);
        }

        // GET: /Courses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Trainer)
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Employee)
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
                return NotFound();

            var model = new CourseDetailsViewModel
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                Duration = course.Duration,
                TrainerName = course.Trainer.FirstName + " " + course.Trainer.LastName,
                Enrollments = course.Enrollments.Select(e => new EnrollmentItemViewModel
                {
                    EmployeeName = e.Employee.FirstName + " " + e.Employee.LastName,
                    EnrollmentDate = e.EnrollmentDate,
                    CompletionStatus = e.CompletionStatus
                }).ToList()
            };

            return View(model);
        }

        // GET: /Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Courses/Create
        [HttpPost]
        public async Task<IActionResult> Create(CourseEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var course = new Course
            {
                Title = model.Title,
                Description = model.Description,
                Duration = model.Duration,
                TrainerId = model.TrainerId
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound();

            var model = new CourseEditViewModel
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                Duration = course.Duration,
                TrainerId = course.TrainerId
            };

            return View(model);
        }

        // POST: /Courses/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(CourseEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var course = await _context.Courses.FindAsync(model.CourseId);
            if (course == null)
                return NotFound();

            course.Title = model.Title;
            course.Description = model.Description;
            course.Duration = model.Duration;
            course.TrainerId = model.TrainerId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
