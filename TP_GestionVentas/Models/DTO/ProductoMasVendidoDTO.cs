namespace TP_GestionVentas.Models.DTOs
{
    public class ProductoMasVendidoDTO
    {
        public string Producto { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int CantidadVendida { get; set; }
        public decimal TotalIngresado { get; set; }
    }
}