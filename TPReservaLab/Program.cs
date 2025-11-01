using Microsoft.Extensions.Hosting;
using TPReservaLab.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace TPReservaLab
{
    internal static class Program
    {
        public static IHost? AppHost { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Crear y configurar el Host (Contenedor DI)
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // A. Registrar el DbContext con la cadena de conexión
                    services.AddDbContext<ReservaLabContext>(options =>
                    {
                        // ASEGÚRESE DE QUE ESTA CADENA ES LA CORRECTA Y FUNCIONAL:
                        options.UseSqlServer("Server=localhost; Database=TPReservaLab; User=sa; Password=123456; Trusted_Connection=True; TrustServerCertificate=True;");
                    });

                    // B. Registrar Repositorios (Interfaces y Clases)
                    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                    services.AddScoped<ILaboratorioRepository, LaboratorioRepository>();
                    services.AddScoped<IReservaRepository, ReservaRepository>();


                    // C. Registrar Controladores
                    services.AddTransient<LaboratorioController>();
                    services.AddTransient<ReservaController>();


                    // D. Registrar Formularios (Vistas)
                    services.AddTransient<frmMenuPrincipal>();
                    services.AddTransient<frmLaboratorios>();
                    services.AddTransient<frmEditLaboratorio>();
                    services.AddTransient<frmReservas>();
                    services.AddTransient<frmEditReserva>();

                })
                .Build();

            // 2. Iniciar el Host
            AppHost.Start();

            // 3. Obtener el formulario principal del contenedor (DI)
            var mainForm = AppHost.Services.GetRequiredService<frmMenuPrincipal>();
            Application.Run(mainForm);
        }
    }
}