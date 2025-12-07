namespace TP_GestionVentas.Models.DTOs
{
    public class VentasTotalesDTO
    {
        public string Etiqueta { get; set; } = string.Empty; // Aquí guardaremos el Nombre de Sucursal o Vendedor
        public int CantidadOperaciones { get; set; }
        public decimal TotalFacturado { get; set; }
    }
}