using System;
using System.ComponentModel.DataAnnotations;

namespace EventosEnLineaVariados.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Imagen { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }

        [Required, StringLength(255)]
        public string Descripcion { get; set; }

        [Required, StringLength(150)]
        public string LugarDondeSeRealiza { get; set; }

        public int ProvinciaId { get; set; }
        public int CantonId { get; set; }
        public int DistritoId { get; set; }

        [Required, StringLength(255)]
        public string DireccionExacta { get; set; }

        public string Observaciones { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaModificacion { get; set; } = DateTime.UtcNow;
    }
}
