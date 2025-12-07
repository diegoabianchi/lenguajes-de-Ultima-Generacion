using Microsoft.EntityFrameworkCore;
using TP_GestionVentas.Data;
using TP_GestionVentas.Models;
using TP_GestionVentas.Models.DTOs;

namespace TP_GestionVentas.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(TechStoreContext context) : base(context)
        {
        }

        // Trae todos los productos INCLUYENDO la categoría (JOIN)
        public IEnumerable<Producto> GetAllCompleto()
        {
            return _context.Productos
                .Include(p => p.Categoria) // <--- CLAVE: Carga la entidad relacionada
                .OrderBy(p => p.Nombre)
                .ToList();
        }

        public IEnumerable<Producto> Search(string valor)
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.Nombre.Contains(valor) || p.Codigo.Contains(valor))
                .ToList();
        }

        // Valida si un código ya existe (excluyendo el propio producto si es edición)
        public bool ExisteCodigo(string codigo, int idExcluir = 0)
        {
            return _context.Productos.Any(p => p.Codigo == codigo && p.ProductoId != idExcluir);
        }

        // Suma el stock de todas las sucursales para este producto
        public int GetStockTotal(int productoId)
        {
            return _context.Stocks
                .Where(s => s.ProductoId == productoId)
                .Sum(s => s.Cantidad);
        }

        // Stock específico en una sucursal
        public int GetStockPorSucursal(int productoId, int sucursalId)
        {
            var stock = _context.Stocks
                .FirstOrDefault(s => s.ProductoId == productoId && s.SucursalId == sucursalId);

            return stock != null ? stock.Cantidad : 0;
        }

        public IEnumerable<StockDTO> GetStockDetallado(int? sucursalId, string busqueda)
        {
            // Empezamos consultando la tabla de Stocks
            var query = _context.Stocks
                .Include(s => s.Producto)
                .ThenInclude(p => p.Categoria)
                .Include(s => s.Sucursal)
                .AsQueryable();

            // Filtro 1: Por Sucursal (si viene null o 0, trae de todas)
            if (sucursalId.HasValue && sucursalId.Value > 0)
            {
                query = query.Where(s => s.SucursalId == sucursalId.Value);
            }

            // Filtro 2: Por Nombre o Código de producto
            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(s => s.Producto.Nombre.Contains(busqueda) || s.Producto.Codigo.Contains(busqueda));
            }

            // Proyección a DTO (Select)
            return query.Select(s => new StockDTO
            {
                Codigo = s.Producto.Codigo,
                Producto = s.Producto.Nombre,
                Categoria = s.Producto.Categoria.Nombre,
                Sucursal = s.Sucursal.Nombre,
                Cantidad = s.Cantidad
            })
            .OrderBy(x => x.Sucursal)
            .ThenBy(x => x.Producto)
            .ToList();
        }

        public void AgregarStock(int productoId, int sucursalId, int cantidad)
        {
            var stock = _context.Stocks.FirstOrDefault(s => s.ProductoId == productoId && s.SucursalId == sucursalId);
            if (stock == null)
            {
                stock = new Stock { ProductoId = productoId, SucursalId = sucursalId, Cantidad = cantidad };
                _context.Stocks.Add(stock);
            }
            else
            {
                stock.Cantidad += cantidad;
                _context.Stocks.Update(stock);
            }
            _context.SaveChanges();
        }
    }
}