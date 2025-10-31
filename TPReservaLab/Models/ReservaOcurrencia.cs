using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("ReservaOcurrencia")]
public class ReservaOcurrencia
{
    [Key]
    public int OcurrenciaId { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    // Claves Foráneas
    public int ReservaId { get; set; }
    public int LaboratorioId { get; set; }

    // Propiedades de navegación
    public Reserva Reserva { get; set; } = null!;
    public Laboratorio Laboratorio { get; set; } = null!;
}