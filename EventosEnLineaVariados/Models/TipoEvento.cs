using System;
using System.ComponentModel.DataAnnotations;

namespace EventosEnLineaVariados.Models
{
    public class TipoEvento
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Descripcion { get; set; }

        [Required, StringLength(50)]
        public string NombreCorto { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaModificacion { get; set; } = DateTime.UtcNow;
    }
}
