using Corporate_Training_Program_System.Data;
using Corporate_Training_Program_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corporate_Training_Program_System.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
