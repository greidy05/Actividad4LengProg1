using System;
using System.Collections.Generic;

namespace Actividad4LengProg.Models;

public partial class Estudiante
{
    public string Matricula { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public string Carrera { get; set; } = null!;

    public string CorreoInstitucional { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string Genero { get; set; } = null!;

    public string Turno { get; set; } = null!;

    public string TipoIngreso { get; set; } = null!;

    public bool EstaBecado { get; set; }

    public int? PorcentajeBeca { get; set; }

    public bool Terminos { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
