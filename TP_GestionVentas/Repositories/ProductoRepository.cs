using Microsoft.EntityFrameworkCore;
using TP_GestionVentas.Data;
using TP_GestionVentas.Models;

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
    }
}