using Microsoft.EntityFrameworkCore;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Data
{
    public class TechStoreContext : DbContext
    {
        // Constructor que acepta las opciones de configuración (cadena de conexión)
        // Esto es fundamental para la Inyección de Dependencias en Program.cs
        public TechStoreContext(DbContextOptions<TechStoreContext> options) : base(options)
        {
        }

        // =========================================
        // DBSETS (Tablas)
        // =========================================
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }

        // =========================================
        // CONFIGURACIÓN FLUENT API (Reglas adicionales)
        // =========================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Configuración de STOCK
            // Restricción Única: No puede haber dos registros del mismo producto en la misma sucursal.
            modelBuilder.Entity<Stock>()
                .HasIndex(s => new { s.ProductoId, s.SucursalId })
                .IsUnique();

            // 2. Configuración de CUIT/DNI Único
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.CUIT_DNI)
                .IsUnique();

            // 3. Configuración de Código de Producto Único
            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Codigo)
                .IsUnique();

            // 4. Configuración de Delete Behavior (Opcional pero recomendado)
            // Evitar borrado en cascada accidental en ventas si se borra un cliente
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}