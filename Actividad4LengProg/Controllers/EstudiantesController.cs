using Actividad4LengProg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly LengProg3DbContext _context;

        public EstudiantesController(LengProg3DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Estudiante model)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(model);
                _context.SaveChanges();
                TempData["mensaje"] = "Estudiante registrado exitosamente.";
                return RedirectToAction("Lista");
            }
            return View("Index", model);
        }

        public IActionResult Lista()
        {
            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);
        }

        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Editar(Estudiante model)
        {
            if (ModelState.IsValid)
            {
                var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == model.Matricula);
                if (estudiante == null) return NotFound();

                estudiante.NombreCompleto = model.NombreCompleto;
                estudiante.Carrera = model.Carrera;
                estudiante.CorreoInstitucional = model.CorreoInstitucional;
                estudiante.Telefono = model.Telefono;
                estudiante.FechaNacimiento = model.FechaNacimiento;
                estudiante.Genero = model.Genero;
                estudiante.Turno = model.Turno;
                estudiante.TipoIngreso = model.TipoIngreso;
                estudiante.EstaBecado = model.EstaBecado;
                estudiante.PorcentajeBeca = model.EstaBecado ? model.PorcentajeBeca : null;
                estudiante.Terminos = model.Terminos;

                _context.SaveChanges();
                TempData["mensaje"] = "Estudiante editado correctamente.";
                return RedirectToAction("Lista");
            }
            return View(model);
        }

        public IActionResult Eliminar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null) return NotFound();

            _context.Estudiantes.Remove(estudiante);
            _context.SaveChanges();

            TempData["mensaje"] = "Estudiante eliminado.";
            return RedirectToAction("Lista");
        }
    }
}
