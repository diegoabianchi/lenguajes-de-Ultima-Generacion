using TP_GestionVentas.Models;

namespace TP_GestionVentas.Repositories
{
    public interface IProductoRepository : IRepository<Producto>
    {
        // Método para traer productos con su Categoría cargada (para la grilla)
        IEnumerable<Producto> GetAllCompleto();

        // Búsquedas específicas
        IEnumerable<Producto> Search(string valor); // Busca por nombre o código
        bool ExisteCodigo(string codigo, int idExcluir = 0); // Para validar unicidad al editar

        // Consultas de Stock (Requerimiento funcional)
        int GetStockTotal(int productoId);
        int GetStockPorSucursal(int productoId, int sucursalId);
        IEnumerable<TP_GestionVentas.Models.DTOs.StockDTO> GetStockDetallado(int? sucursalId, string busqueda);
        void AgregarStock(int productoId, int sucursalId, int cantidad);
    }
}