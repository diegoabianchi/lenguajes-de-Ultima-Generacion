using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TP_GestionVentas.Data;
using TP_GestionVentas.Views;
using TP_GestionVentas.Repositories;
using TP_GestionVentas.Controllers;

namespace TP_GestionVentas
{
    internal static class Program
    {
        // Propiedad estática para acceder al Host si fuera necesario
        public static IHost? AppHost { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Configuración del Contenedor de Inyección de Dependencias
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // A. Registrar el Contexto de Base de Datos (cadena de conexión)
                    services.AddDbContext<TechStoreContext>(options =>
                    {
                        options.UseSqlServer("Server=localhost; Database=TP_GestionVentas; User=sa; Password=123456; Trusted_Connection=True; TrustServerCertificate=True;");
                    });

                    // B. Registrar Repositorios
                    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                    services.AddScoped<IProductoRepository, ProductoRepository>();
                    services.AddScoped<IClienteRepository, ClienteRepository>();
                    services.AddScoped<IVendedorRepository, VendedorRepository>();
                    services.AddScoped<IVentaRepository, VentaRepository>();
                    services.AddScoped<IReporteRepository, ReporteRepository>();

                    // C. Registrar Controladores
                    services.AddTransient<ProductoController>();
                    services.AddTransient<ClienteController>();
                    services.AddTransient<VendedorController>();
                    services.AddTransient<VentaController>();
                    services.AddTransient<ReporteController>();

                    // D. Registrar Formularios (Vistas)
                    services.AddTransient<frmMenuPrincipal>();
                    services.AddTransient<frmGestionProductos>();
                    services.AddTransient<frmEditProducto>();
                    services.AddTransient<frmGestionClientes>();
                    services.AddTransient<frmEditCliente>();
                    services.AddTransient<frmGestionVendedores>();
                    services.AddTransient<frmEditVendedor>();
                    services.AddTransient<frmRegistrarVenta>();
                    services.AddTransient<frmConsultaStock>();
                    services.AddTransient<frmReportes>();
                    services.AddTransient<frmHistorialVentas>();

                })
                .Build();

            // 2. Iniciar el Host (gestiona el ciclo de vida de los servicios)
            AppHost.Start();

            // 3. Arrancar la aplicación solicitando el formulario principal al contenedor
            // Esto permite que frmMenuPrincipal reciba dependencias en su constructor automáticamente.
            var mainForm = AppHost.Services.GetRequiredService<frmMenuPrincipal>();
            Application.Run(mainForm);
        }
    }
}