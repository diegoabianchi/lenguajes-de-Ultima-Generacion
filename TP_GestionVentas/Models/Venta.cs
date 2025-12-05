using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_GestionVentas.Models
{
    [Table("Venta")]
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        public DateTime FechaVenta { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(10, 2)")]
        public decimal DescuentoTotal { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalFinal { get; set; }

        // Claves Foráneas
        public int SucursalId { get; set; }
        public int VendedorId { get; set; }
        public int MetodoPagoId { get; set; }
        public int? ClienteId { get; set; } // Puede ser nulo (Venta anónima)

        // Navegación
        [ForeignKey("SucursalId")]
        public virtual Sucursal Sucursal { get; set; } = null!;

        [ForeignKey("VendedorId")]
        public virtual Vendedor Vendedor { get; set; } = null!;

        [ForeignKey("MetodoPagoId")]
        public virtual MetodoPago MetodoPago { get; set; } = null!;

        [ForeignKey("ClienteId")]
        public virtual Cliente? Cliente { get; set; } // Puede ser null

        public virtual ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}