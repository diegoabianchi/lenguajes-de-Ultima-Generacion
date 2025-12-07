using System;
using System.Collections.Generic;
using TP_GestionVentas.Models.DTOs;
using TP_GestionVentas.Repositories;

namespace TP_GestionVentas.Controllers
{
    public class ReporteController
    {
        private readonly IReporteRepository _repository;

        // Inyección de Dependencias: El sistema nos dará el repositorio listo
        public ReporteController(IReporteRepository repository)
        {
            _repository = repository;
        }

        // 1. Reporte de Productos Más Vendidos
        public List<ProductoMasVendidoDTO> ReporteProductosTop(DateTime desde, DateTime hasta)
        {
            return (List<ProductoMasVendidoDTO>)_repository.GetProductosMasVendidos(desde, hasta);
        }

        // 2. Reporte de Ventas por Sucursal
        public List<VentasTotalesDTO> ReporteVentasPorSucursal(DateTime desde, DateTime hasta)
        {
            return (List<VentasTotalesDTO>)_repository.GetVentasPorSucursal(desde, hasta);
        }

        // 3. Reporte de Ventas por Vendedor
        public List<VentasTotalesDTO> ReporteVentasPorVendedor(DateTime desde, DateTime hasta)
        {
            return (List<VentasTotalesDTO>)_repository.GetVentasPorVendedor(desde, hasta);
        }
    }
}