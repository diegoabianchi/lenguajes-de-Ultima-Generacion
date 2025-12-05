using System;
using System.Collections.Generic;
using System.Linq;
using TP_GestionVentas.Models;
using TP_GestionVentas.Repositories;

namespace TP_GestionVentas.Controllers
{
    public class ProductoController
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IRepository<Categoria> _categoriaRepository;

        // Constructor con Inyección de Dependencias
        public ProductoController(IProductoRepository productoRepository, IRepository<Categoria> categoriaRepository)
        {
            _productoRepository = productoRepository;
            _categoriaRepository = categoriaRepository;
        }

        // ==========================================
        // MÉTODOS DE LECTURA (Para la Grilla y UI)
        // ==========================================

        public List<Producto> ObtenerTodos()
        {
            // Usamos el método específico que trae la Categoría incluida
            return _productoRepository.GetAllCompleto().ToList();
        }

        public List<Producto> BuscarProductos(string busqueda)
        {
            return _productoRepository.Search(busqueda).ToList();
        }

        public List<Categoria> ObtenerCategorias()
        {
            return _categoriaRepository.GetAll().OrderBy(c => c.Nombre).ToList();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productoRepository.GetById(id);
        }

        // ==========================================
        // MÉTODOS DE ESCRITURA (Validaciones y Persistencia)
        // ==========================================

        public void CrearProducto(Producto producto)
        {
            ValidarProducto(producto);

            // Regla de Negocio: El código no puede repetirse
            if (_productoRepository.ExisteCodigo(producto.Codigo))
            {
                throw new Exception("El código de producto ya existe en la base de datos.");
            }

            _productoRepository.Add(producto);
            _productoRepository.SaveChanges();
        }

        public void ModificarProducto(Producto producto)
        {
            ValidarProducto(producto);

            // Regla de Negocio: El código no puede repetirse (excluyendo el propio producto)
            if (_productoRepository.ExisteCodigo(producto.Codigo, producto.ProductoId))
            {
                throw new Exception("El código ya está siendo usado por otro producto.");
            }

            _productoRepository.Update(producto);
            _productoRepository.SaveChanges();
        }

        public void EliminarProducto(int id)
        {
            // Validación: No borrar si tiene stock físico
            int stockTotal = _productoRepository.GetStockTotal(id);
            if (stockTotal > 0)
            {
                throw new Exception($"No se puede eliminar el producto porque tiene {stockTotal} unidades en stock. Realice un ajuste de stock a cero primero.");
            }

            // Nota: Si tiene ventas asociadas, la BD lanzará un error de Clave Foránea (FK).
            // Podríamos validar eso aquí consultando ventas, o dejar que el try-catch de la vista lo capture.
            // Por ahora, usamos la eliminación estándar.

            var producto = _productoRepository.GetById(id);
            if (producto != null)
            {
                _productoRepository.Remove(producto);
                _productoRepository.SaveChanges();
            }
        }

        // Validación privada reutilizable
        private void ValidarProducto(Producto p)
        {
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(p.Codigo))
                throw new Exception("El código es obligatorio.");

            if (p.Precio < 0)
                throw new Exception("El precio no puede ser negativo.");

            if (p.CategoriaId <= 0)
                throw new Exception("Debe seleccionar una categoría válida.");
        }
    }
}