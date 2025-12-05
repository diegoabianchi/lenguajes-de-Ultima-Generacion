using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_GestionVentas.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        public int Cantidad { get; set; }

        // Claves foráneas
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }

        // Navegación
        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; } = null!;

        [ForeignKey("SucursalId")]
        public virtual Sucursal Sucursal { get; set; } = null!;
    }
}