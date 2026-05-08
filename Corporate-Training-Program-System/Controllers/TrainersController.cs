using Corporate_Training_Program_System.Data;
using Corporate_Training_Program_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corporate_Training_Program_System.Controllers
{
    public class TrainersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var trainers = _context.Trainers.ToList();
            return View(trainers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trainer trainer)
        {
            if (!ModelState.IsValid)
                return View(trainer);

            _context.Trainers.Add(trainer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var trainer = _context.Trainers.Find(id);
            if (trainer == null) return NotFound();

            return View(trainer);
        }

        [HttpPost]
        public IActionResult Edit(Trainer trainer)
        {
            if (!ModelState.IsValid)
                return View(trainer);

            _context.Trainers.Update(trainer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var trainer = _context.Trainers.Find(id);
            if (trainer == null) return NotFound();

            return View(trainer);
        }

        public IActionResult Delete(int id)
        {
            var trainer = _context.Trainers.Find(id);
            if (trainer == null) return NotFound();

            return View(trainer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var trainer = _context.Trainers.Find(id);
            if (trainer == null) return NotFound();

            _context.Trainers.Remove(trainer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
