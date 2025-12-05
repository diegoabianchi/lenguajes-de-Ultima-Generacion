using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_GestionVentas.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        [Key]
        public int VendedorId { get; set; }

        [Required]
        [StringLength(150)]
        public string NombreCompleto { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}