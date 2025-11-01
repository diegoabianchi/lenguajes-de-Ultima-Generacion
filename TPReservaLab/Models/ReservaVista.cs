public class ReservaVista
{
    // Datos clave (el ID se mantiene oculto para la edición)
    public int ReservaId { get; set; }
    public string TipoReserva { get; set; }

    // Datos de la reserva (formato mejorado)
    public DateTime Inicio { get; set; }
    public DateTime Fin { get; set; }

    // Nombres de las entidades relacionadas
    public string Laboratorio { get; set; }
    public string Profesor { get; set; }
    public string Asignatura { get; set; }
    public string Carrera { get; set; }
    public string Comision { get; set; }
    public string Observaciones { get; set; }
    public bool Activa { get; set; }

    // CAMPOS PARA LA HERENCIA
    public string Frecuencia { get; set; }
    public int? CantidadSemanas { get; set; } 
}