using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg.Models
{
    public class MateriaViewModel
    {
        [Required]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Range(1, 10)]
        public int Creditos { get; set; }

        [Required]
        public string Carrera { get; set; }
    }
}
