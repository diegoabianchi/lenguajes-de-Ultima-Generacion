using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_GestionVentas.Models
{
    [Table("DetalleVenta")]
    public class DetalleVenta
    {
        [Key]
        public int DetalleVentaId { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal DescuentoLinea { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Subtotal { get; set; }

        // Claves Foráneas
        public int VentaId { get; set; }
        public int ProductoId { get; set; }

        // Navegación
        [ForeignKey("VentaId")]
        public virtual Venta Venta { get; set; } = null!;

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; } = null!;
    }
}