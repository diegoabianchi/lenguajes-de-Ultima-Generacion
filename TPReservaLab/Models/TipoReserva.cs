using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("TipoReserva")]
public class TipoReserva
{
    [Key]
    public int TipoReservaId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }

    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}