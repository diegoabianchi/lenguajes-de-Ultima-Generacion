using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Comision")]
public class Comision
{
    [Key]
    public int ComisionId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public int Anio { get; set; }

    // Clave Foránea
    public int AsignaturaId { get; set; }
    // Propiedad de navegación
    public Asignatura Asignatura { get; set; } = null!;

    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}