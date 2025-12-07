using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TP_GestionVentas.Data;
using TP_GestionVentas.Models.DTOs;

namespace TP_GestionVentas.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly TechStoreContext _context;

        public ReporteRepository(TechStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductoMasVendidoDTO> GetProductosMasVendidos(DateTime desde, DateTime hasta)
        {
            return _context.DetallesVenta
                .Include(d => d.Venta)
                .Include(d => d.Producto)
                .ThenInclude(p => p.Categoria)
                .Where(d => d.Venta.FechaVenta >= desde && d.Venta.FechaVenta <= hasta)
                .GroupBy(d => new { d.Producto.Nombre, Categoria = d.Producto.Categoria.Nombre })
                .Select(g => new ProductoMasVendidoDTO
                {
                    Producto = g.Key.Nombre,
                    Categoria = g.Key.Categoria,
                    CantidadVendida = g.Sum(x => x.Cantidad),
                    TotalIngresado = g.Sum(x => x.Subtotal)
                })
                .OrderByDescending(x => x.CantidadVendida)
                .Take(10) // Traemos solo los 10 mejores
                .ToList();
        }

        public IEnumerable<VentasTotalesDTO> GetVentasPorSucursal(DateTime desde, DateTime hasta)
        {
            return _context.Ventas
                .Include(v => v.Sucursal)
                .Where(v => v.FechaVenta >= desde && v.FechaVenta <= hasta)
                .GroupBy(v => v.Sucursal.Nombre)
                .Select(g => new VentasTotalesDTO
                {
                    Etiqueta = g.Key,
                    CantidadOperaciones = g.Count(),
                    TotalFacturado = g.Sum(x => x.TotalFinal)
                })
                .OrderByDescending(x => x.TotalFacturado)
                .ToList();
        }

        public IEnumerable<VentasTotalesDTO> GetVentasPorVendedor(DateTime desde, DateTime hasta)
        {
            return _context.Ventas
                .Include(v => v.Vendedor)
                .Where(v => v.FechaVenta >= desde && v.FechaVenta <= hasta)
                .GroupBy(v => v.Vendedor.NombreCompleto)
                .Select(g => new VentasTotalesDTO
                {
                    Etiqueta = g.Key,
                    CantidadOperaciones = g.Count(),
                    TotalFacturado = g.Sum(x => x.TotalFinal)
                })
                .OrderByDescending(x => x.TotalFacturado)
                .ToList();
        }
    }
}