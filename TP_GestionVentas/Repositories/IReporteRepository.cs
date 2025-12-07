using System;
using System.Collections.Generic;
using TP_GestionVentas.Models.DTOs; // Importante para reconocer los DTOs

namespace TP_GestionVentas.Repositories
{
    public interface IReporteRepository
    {
        // Top productos más vendidos
        IEnumerable<ProductoMasVendidoDTO> GetProductosMasVendidos(DateTime desde, DateTime hasta);

        // Ventas agrupadas por Sucursal
        IEnumerable<VentasTotalesDTO> GetVentasPorSucursal(DateTime desde, DateTime hasta);

        // Ventas agrupadas por Vendedor
        IEnumerable<VentasTotalesDTO> GetVentasPorVendedor(DateTime desde, DateTime hasta);
    }
}