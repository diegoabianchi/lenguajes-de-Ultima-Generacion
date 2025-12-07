using System;

namespace TP_GestionVentas.Models.DTOs
{
    public class VentaHistorialDTO
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } // Nombre del cliente o "Consumidor Final"
        public string Vendedor { get; set; }
        public string MetodoPago { get; set; }
        public decimal Total { get; set; }
    }
}