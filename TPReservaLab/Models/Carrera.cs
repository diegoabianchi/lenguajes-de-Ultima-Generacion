using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Carrera")]
public class Carrera
{
    [Key]
    public int CarreraId { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}