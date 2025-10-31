using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Reserva")]
public class Reserva
{
    [Key]
    public int ReservaId { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public string? Observaciones { get; set; }
    public bool IsActive { get; set; } = true;

    // Claves Foráneas
    public int TipoReservaId { get; set; }
    public int LaboratorioId { get; set; }
    public int ProfesorId { get; set; }
    public int CarreraId { get; set; }
    public int AsignaturaId { get; set; }
    public int ComisionId { get; set; }

    // Propiedades de navegación
    public TipoReserva TipoReserva { get; set; } = null!;
    public Laboratorio Laboratorio { get; set; } = null!;
    public Profesor Profesor { get; set; } = null!;
    public Carrera Carrera { get; set; } = null!;
    public Asignatura Asignatura { get; set; } = null!;
    public Comision Comision { get; set; } = null!;

    // Propiedades de navegación para la herencia (opcional)
    public ICollection<ReservaOcurrencia> Ocurrencias { get; set; } = new List<ReservaOcurrencia>();
}