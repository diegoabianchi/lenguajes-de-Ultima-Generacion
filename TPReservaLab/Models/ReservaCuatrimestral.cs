using System.ComponentModel.DataAnnotations.Schema;

[Table("ReservaCuatrimestral")]
public class ReservaCuatrimestral : Reserva
{
    public string Frecuencia { get; set; } = string.Empty; // Semanal o Quincenal
    public DateTime FechaFinCuatri { get; set; }
}