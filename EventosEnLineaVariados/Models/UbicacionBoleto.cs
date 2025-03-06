using System;
using System.ComponentModel.DataAnnotations;

namespace EventosEnLineaVariados.Models
{
    public class UbicacionBoleto
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Seccion { get; set; }

        [Required, StringLength(10)]
        public string Fila { get; set; }

        [Required, StringLength(10)]
        public string Asiento { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaModificacion { get; set; } = DateTime.UtcNow;
    }
}
