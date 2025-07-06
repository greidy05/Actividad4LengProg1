using System;
using System.Collections.Generic;

namespace Actividad4LengProg.Models;

public partial class Materia
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int Creditos { get; set; }

    public string Carrera { get; set; } = null!;

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
