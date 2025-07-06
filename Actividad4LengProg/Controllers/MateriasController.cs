using Actividad4LengProg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg.Controllers
{
    public class MateriasController : Controller
    {
        private readonly LengProg3DbContext _context;

        public MateriasController(LengProg3DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var materias = _context.Materias.ToList();
            return View(materias);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Materias.Add(materia);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materia);
        }

        [HttpGet]
        public IActionResult Editar(string codigo)
        {
            var materia = _context.Materias.FirstOrDefault(m => m.Codigo == codigo);
            if (materia == null) return NotFound();
            return View(materia);
        }

        [HttpPost]
        public IActionResult Editar(Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Materias.Update(materia);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materia);
        }

        public IActionResult Eliminar(string codigo)
        {
            var materia = _context.Materias.FirstOrDefault(m => m.Codigo == codigo);
            if (materia == null) return NotFound();

            _context.Materias.Remove(materia);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
