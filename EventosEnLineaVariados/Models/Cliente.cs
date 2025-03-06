using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosEnLineaVariados.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(100)]
        public string Apellidos { get; set; }

        [Required, EmailAddress, StringLength(150)]
        public string Correo { get; set; }

        [Required, StringLength(255)]
        public string Clave { get; set; }

        public int ProvinciaId { get; set; }
        public int CantonId { get; set; }
        public int DistritoId { get; set; }

        [Required, StringLength(255)]
        public string DireccionExacta { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaModificacion { get; set; } = DateTime.UtcNow;
    }
}
