using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_GestionVentas.Models
{
    [Table("Sucursal")]
    public class Sucursal
    {
        [Key]
        public int SucursalId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Direccion { get; set; }

        // Navegación
        public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}