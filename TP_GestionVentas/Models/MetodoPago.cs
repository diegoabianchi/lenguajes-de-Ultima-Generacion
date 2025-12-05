using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_GestionVentas.Models
{
    [Table("MetodoPago")]
    public class MetodoPago
    {
        [Key]
        public int MetodoPagoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }
}