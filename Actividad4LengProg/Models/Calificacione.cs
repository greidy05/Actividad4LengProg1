using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg.Models;

public partial class Calificacione
{
    public int Id { get; set; }

    [Required(ErrorMessage = "La matrícula del estudiante es obligatoria.")]
    [Display(Name = "Estudiante")]
    public string MatriculaEstudiante { get; set; } = null!;

    [Required(ErrorMessage = "El código de la materia es obligatorio.")]
    [Display(Name = "Materia")]
    public string CodigoMateria { get; set; } = null!;

    [Required(ErrorMessage = "La nota es obligatoria.")]
    [Range(0, 100, ErrorMessage = "La nota debe estar entre 0 y 100.")]
    public int Nota { get; set; }

    [Required(ErrorMessage = "El periodo es obligatorio.")]
    [StringLength(20, ErrorMessage = "El periodo no debe exceder los 20 caracteres.")]
    public string Periodo { get; set; } = null!;

    public virtual Materia CodigoMateriaNavigation { get; set; } = null!;
    public virtual Estudiante MatriculaEstudianteNavigation { get; set; } = null!;
}
