using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_GestionVentas.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [StringLength(20)]
        public string? CUIT_DNI { get; set; }

        [Required]
        [StringLength(150)]
        public string NombreCompleto { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoCliente { get; set; } = "Minorista"; // "Minorista" o "Mayorista"

        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}