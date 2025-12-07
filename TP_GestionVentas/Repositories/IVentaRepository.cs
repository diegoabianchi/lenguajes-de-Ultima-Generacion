using System.Collections.Generic;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Repositories
{
    public interface IVentaRepository : IRepository<Venta>
    {
        // Métodos para llenar los ComboBoxes de la interfaz
        IEnumerable<Vendedor> GetVendedores();
        IEnumerable<MetodoPago> GetMetodosPago();
        IEnumerable<Sucursal> GetSucursales();
        IEnumerable<Cliente> GetClientes();

        void CrearVentaTransaccional(Venta venta);

        IEnumerable<TP_GestionVentas.Models.DTOs.VentaHistorialDTO> GetHistorial(DateTime desde, DateTime hasta, int? clienteId = null);

        Venta? GetVentaConDetalles(int id);
    }
}