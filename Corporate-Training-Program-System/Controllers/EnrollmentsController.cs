using Corporate_Training_Program_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Corporate_Training_Program_System.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Enrollments
                .Include(e => e.Employee)
                .Include(e => e.Course)
                .ToListAsync();

            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Employees = _context.Employees.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Employees = _context.Employees.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return View(enrollment);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var enrollment = await _context.Enrollments
                .Include(e => e.Employee)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.EnrollmentId == id);

            if (enrollment == null)
                return NotFound();

            return View(enrollment);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
