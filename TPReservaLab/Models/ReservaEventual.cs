using System.ComponentModel.DataAnnotations.Schema;


[Table("ReservaEventual")]
public class ReservaEventual : Reserva
{
    public int CantidadSemanas { get; set; }
}