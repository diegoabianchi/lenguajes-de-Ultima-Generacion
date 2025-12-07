using System;
using System.Collections.Generic;
using System.Linq;
using TP_GestionVentas.Models;
using TP_GestionVentas.Repositories;

namespace TP_GestionVentas.Controllers
{
    public class VentaController
    {
        private readonly IVentaRepository _ventaRepo;
        private readonly IProductoRepository _productoRepo; // Para buscar productos al agregarlos al carrito

        public VentaController(IVentaRepository ventaRepo, IProductoRepository productoRepo)
        {
            _ventaRepo = ventaRepo;
            _productoRepo = productoRepo;
        }

        // --- Datos para cargar la pantalla ---
        public List<Sucursal> ObtenerSucursales() => _ventaRepo.GetSucursales().ToList();
        public List<Vendedor> ObtenerVendedores() => _ventaRepo.GetVendedores().ToList();
        public List<Cliente> ObtenerClientes() => _ventaRepo.GetClientes().ToList();
        public List<MetodoPago> ObtenerMetodosPago() => _ventaRepo.GetMetodosPago().ToList();
        public List<Producto> ObtenerTodosProductos() => _productoRepo.GetAllCompleto().ToList();
        public List<Producto> ListarProductos() => _productoRepo.GetAll().ToList();


        public void ProcesarVenta(Venta venta)
        {
            if (venta.SucursalId == 0) throw new Exception("Seleccione una Sucursal.");
            if (venta.VendedorId == 0) throw new Exception("Seleccione un Vendedor.");
            if (venta.MetodoPagoId == 0) throw new Exception("Seleccione un Método de Pago.");
            if (venta.Detalles.Count == 0) throw new Exception("El carrito está vacío. Agregue productos.");

            _ventaRepo.CrearVentaTransaccional(venta);
        }

        public List<Producto> BuscarProductosLista(string busqueda)
        {
            // Si la búsqueda es nula, aseguramos que sea cadena vacía para que traiga todo
            string termino = busqueda ?? string.Empty;

            // Reutilizamos el método Search del repositorio de productos
            return _productoRepo.Search(termino).ToList();
        }

        public List<TP_GestionVentas.Models.DTOs.VentaHistorialDTO> ObtenerHistorial(DateTime desde, DateTime hasta, int? clienteId = null)
        {
            return _ventaRepo.GetHistorial(desde, hasta, clienteId).ToList();
        }

        public Venta? ObtenerDetalleVenta(int ventaId)
        {
            return _ventaRepo.GetVentaConDetalles(ventaId);
        }

        // Método para obtener datos de un cliente específico (y saber si es Mayorista)
        public Cliente? ObtenerDatosCliente(int clienteId)
        {
            return ObtenerClientes().FirstOrDefault(c => c.ClienteId == clienteId);
        }
    }
}