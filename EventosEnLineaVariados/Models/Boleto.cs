using System;
using System.ComponentModel.DataAnnotations;

namespace EventosEnLineaVariados.Models
{
    public class Boleto
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Seccion { get; set; }

        [Required, StringLength(50)]
        public string Bloque { get; set; }

        [Required, StringLength(255)]
        public string Descripcion { get; set; }

        [Required, StringLength(50)]
        public string TipoBoleto { get; set; } // Regular, VIP

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public decimal Cargos { get; set; }

        [Required]
        public decimal PrecioTotal => Precio + Cargos;

        [Required, StringLength(10)]
        public string Moneda { get; set; } // USD, CRC

        [StringLength(255)]
        public string AsientosAsignados { get; set; }

        [Required, StringLength(50)]
        public string FormaEntrega { get; set; } // Electrónica, Física

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaModificacion { get; set; } = DateTime.UtcNow;
    }
}
