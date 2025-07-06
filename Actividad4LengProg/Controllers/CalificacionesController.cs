using Actividad4LengProg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly LengProg3DbContext _context;

        public CalificacionesController(LengProg3DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var calificaciones = _context.Calificaciones
                .Include(c => c.MatriculaEstudianteNavigation)
                .Include(c => c.CodigoMateriaNavigation)
                .ToList();
            return View(calificaciones);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Estudiantes = new SelectList(_context.Estudiantes.ToList(), "Matricula", "NombreCompleto");
            ViewBag.Materias = new SelectList(_context.Materias.ToList(), "Codigo", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("MatriculaEstudiante,CodigoMateria,Nota,Periodo")] Calificacione model)
        {
            if (ModelState.IsValid)
            {
                _context.Calificaciones.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Estudiantes = new SelectList(_context.Estudiantes.ToList(), "Matricula", "NombreCompleto", model.MatriculaEstudiante);
            ViewBag.Materias = new SelectList(_context.Materias.ToList(), "Codigo", "Nombre", model.CodigoMateria);
            return View(model);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var calificacion = _context.Calificaciones.Find(id);
            if (calificacion == null) return NotFound();

            ViewBag.Estudiantes = new SelectList(_context.Estudiantes.ToList(), "Matricula", "NombreCompleto", calificacion.MatriculaEstudiante);
            ViewBag.Materias = new SelectList(_context.Materias.ToList(), "Codigo", "Nombre", calificacion.CodigoMateria);
            return View(calificacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar([Bind("Id,MatriculaEstudiante,CodigoMateria,Nota,Periodo")] Calificacione model)
        {
            if (ModelState.IsValid)
            {
                _context.Calificaciones.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Estudiantes = new SelectList(_context.Estudiantes.ToList(), "Matricula", "NombreCompleto", model.MatriculaEstudiante);
            ViewBag.Materias = new SelectList(_context.Materias.ToList(), "Codigo", "Nombre", model.CodigoMateria);
            return View(model);
        }

        public IActionResult Eliminar(int id)
        {
            var calificacion = _context.Calificaciones.Find(id);
            if (calificacion == null) return NotFound();

            _context.Calificaciones.Remove(calificacion);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
