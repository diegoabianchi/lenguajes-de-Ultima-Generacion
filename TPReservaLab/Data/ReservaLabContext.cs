using Microsoft.EntityFrameworkCore;

public class ReservaLabContext : DbContext
{
    public ReservaLabContext(DbContextOptions<ReservaLabContext> options)
        : base(options)
    {
    }

    // DbSet por cada tabla (entidad) que necesite mapear
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Carrera> Carreras { get; set; }
    public DbSet<Asignatura> Asignaturas { get; set; }
    public DbSet<Comision> Comisiones { get; set; }
    public DbSet<TipoReserva> TiposReserva { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<ReservaCuatrimestral> ReservasCuatrimestrales { get; set; }
    public DbSet<ReservaEventual> ReservasEventuales { get; set; }
    public DbSet<ReservaOcurrencia> ReservaOcurrencias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar Herencia para las reservas
        modelBuilder.Entity<Reserva>()
            .ToTable("Reserva"); // La tabla base

        modelBuilder.Entity<ReservaCuatrimestral>()
            .ToTable("ReservaCuatrimestral"); // La tabla derivada 1

        modelBuilder.Entity<ReservaEventual>()
            .ToTable("ReservaEventual"); // La tabla derivada 2

        // Configurar la clave compuesta para el índice de Ocurrencia
        modelBuilder.Entity<ReservaOcurrencia>()
           .HasIndex(o => new { o.LaboratorioId, o.FechaInicio })
            .HasDatabaseName("IX_ReservaOcurrencia_Lab_Fecha");

        // Eliminacion. Esto desactiva la eliminación en cascada en el nivel de C# y asegura que EF Core NO intente re-crear las FKs con CASCADE,
        // respetando el ON DELETE NO ACTION del script SQL.
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        // Configurar datos iniciales (Seed Data) para TipoReserva
        modelBuilder.Entity<TipoReserva>().HasData(
            new TipoReserva { TipoReservaId = 1, Codigo = "Cuatrimestral", Descripcion = "Reserva recurrente semanal o quincenal" },
            new TipoReserva { TipoReservaId = 2, Codigo = "Eventual", Descripcion = "Reserva eventual por un número determinado de semanas" }
        );

        base.OnModelCreating(modelBuilder);
    }
}