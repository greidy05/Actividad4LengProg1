using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg.Models
{
    public class EstudianteViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Matricula { get; set; }

        [Required]
        public string Carrera { get; set; } // Se llenará desde una lista

        [Required]
        [EmailAddress]
        [Display(Name = "Correo institucional")]
        public string CorreoInstitucional { get; set; }

        [Phone]
        [MinLength(10)]
        public string Telefono { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Genero { get; set; } // Usar radio buttons

        [Required]
        public string Turno { get; set; } // Lista desplegable: Mañana, Tarde, Noche

        [Required]
        [Display(Name = "Tipo de ingreso")]
        public string TipoIngreso { get; set; } // Lista desplegable

        [Display(Name = "¿Está becado?")]
        public bool EstaBecado { get; set; }

        [Range(0, 100)]
        [Display(Name = "Porcentaje de beca")]
        public int? PorcentajeBeca { get; set; }

        [Required(ErrorMessage = "Debe aceptar los términos")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar los términos")]
        [Display(Name = "Términos y condiciones")]
        public bool Terminos { get; set; }
    }
}

