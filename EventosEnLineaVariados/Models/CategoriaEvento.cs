using System;
using System.ComponentModel.DataAnnotations;

namespace EventosEnLineaVariados.Models
{
    public class CategoriaEvento
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Descripcion { get; set; }

        [Required, StringLength(50)]
        public string TipoEvento { get; set; } // Regular, Preferencial

        [Required]
        public decimal Precio { get; set; }

        [Required, StringLength(10)]
        public string Moneda { get; set; } // CRC

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaModificacion { get; set; } = DateTime.UtcNow;
    }
}
