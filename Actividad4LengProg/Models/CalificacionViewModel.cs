using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg.Models
{
    public class CalificacionViewModel
    {
        [Required]
        public string MatriculaEstudiante { get; set; }

        [Required]
        public string CodigoMateria { get; set; }

        [Required]
        [Range(0, 100)]
        public double Nota { get; set; }

        [Required]
        public string Periodo { get; set; }
    }
}

