﻿using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Range(0, int.MaxValue)]
        public int Sueldo { get; set; } = 0;

        [SwaggerSchema(ReadOnly = true)]
        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [SwaggerSchema(ReadOnly = true)]
        [Required]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
