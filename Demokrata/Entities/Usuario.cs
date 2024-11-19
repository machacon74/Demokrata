using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Demokrata.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PrimerNombre { get; set; } = string.Empty;

        [MaxLength(50)]
        public string SegundoNombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string PrimerApellido { get; set; } = string.Empty;

        [MaxLength(50)]
        public string SegundoApellido { get; set; } = string.Empty;

        [Required]
        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;

        [Required]
        public int Sueldo { get; set; } = 0;

        [Required]
        public DateTime FechaCreación { get; set; } = DateTime.Now;

        [Required]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
