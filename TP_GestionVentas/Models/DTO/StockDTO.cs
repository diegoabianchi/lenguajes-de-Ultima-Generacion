namespace TP_GestionVentas.Models.DTOs
{
    public class StockDTO
    {
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public string Sucursal { get; set; }
        public int Cantidad { get; set; }
    }
}