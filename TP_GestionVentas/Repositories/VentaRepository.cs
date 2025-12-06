using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TP_GestionVentas.Data;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Repositories
{
    public class VentaRepository : Repository<Venta>, IVentaRepository
    {
        public VentaRepository(TechStoreContext context) : base(context)
        {
        }

        public IEnumerable<Vendedor> GetVendedores() => _context.Vendedores.Where(x => x.VendedorId > 0).ToList();
        public IEnumerable<MetodoPago> GetMetodosPago() => _context.MetodosPago.ToList();
        public IEnumerable<Sucursal> GetSucursales() => _context.Sucursales.ToList();
        public IEnumerable<Cliente> GetClientes() => _context.Clientes.ToList();

        public void CrearVentaTransaccional(Venta venta)
        {
            // 1. Iniciamos la transacción
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // 2. Recorremos los detalles para validar y descontar stock
                foreach (var item in venta.Detalles)
                {
                    // Buscamos el stock específico de ese producto en esa sucursal
                    var stockRegistro = _context.Stocks
                        .FirstOrDefault(s => s.ProductoId == item.ProductoId && s.SucursalId == venta.SucursalId);

                    // Validaciones de Stock
                    if (stockRegistro == null)
                        throw new Exception($"El producto (ID: {item.ProductoId}) no tiene stock registrado en esta sucursal.");

                    if (stockRegistro.Cantidad < item.Cantidad)
                        throw new Exception($"Stock insuficiente para el producto ID {item.ProductoId}. Disponibles: {stockRegistro.Cantidad}. Solicitados: {item.Cantidad}");

                    // Descontar Stock
                    stockRegistro.Cantidad -= item.Cantidad;
                    _context.Stocks.Update(stockRegistro);
                }

                // 3. Guardar la Venta (EF Core guarda automáticamente los Detalles por la relación)
                _context.Ventas.Add(venta);
                _context.SaveChanges();

                // 4. Todo OK, confirmamos cambios en la BD
                transaction.Commit();
            }
            catch (Exception)
            {
                // Si hubo error, hacemos rollback y re-lanzamos el error para mostrarlo en pantalla
                transaction.Rollback();
                throw; 
            }
        }
    }
}