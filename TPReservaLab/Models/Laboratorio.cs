using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Laboratorio")]
public class Laboratorio
{
    [Key]
    public int LaboratorioId { get; set; }
    public int Numero { get; set; }
    public string UbicacionPiso { get; set; } = string.Empty;
    public int CapacidadPuestos { get; set; }

    // Propiedad de navegación
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}