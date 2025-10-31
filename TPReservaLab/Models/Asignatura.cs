using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Asignatura")]
public class Asignatura
{
    [Key]
    public int AsignaturaId { get; set; }
    public string Nombre { get; set; } = string.Empty;

    // Clave Foránea
    public int CarreraId { get; set; }
    // Propiedad de navegación
    public Carrera Carrera { get; set; } = null!;

    public ICollection<Comision> Comisiones { get; set; } = new List<Comision>();
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}