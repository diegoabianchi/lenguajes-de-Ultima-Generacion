using System.Collections.Generic;
using System.Linq;

public class ReservaController
{
    private readonly IReservaRepository _reservaRepository;

    public ReservaController(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public void AltaReserva(Reserva reserva)
    {
        if (reserva.FechaInicio >= reserva.FechaFin)
        {
            throw new ArgumentException("La fecha de inicio debe ser anterior a la fecha de finalización.");
        }

        // Validación de Horario del Centro (Requisito Funcional). El horario de 7:00 a 23:00 de L a V, S de 8:00 a 12:00
        TimeSpan horaInicio = reserva.FechaInicio.TimeOfDay;
        DayOfWeek dia = reserva.FechaInicio.DayOfWeek;

        if (dia == DayOfWeek.Sunday)
        {
            throw new InvalidOperationException("No se permiten reservas los Domingos.");
        }
        if (dia != DayOfWeek.Saturday && (horaInicio < new TimeSpan(7, 0, 0) || horaInicio > new TimeSpan(23, 0, 0)))
        {
            throw new InvalidOperationException("Horario fuera del rango permitido (Lunes-Viernes: 7:00 a 23:00).");
        }

        // Validación de Conflicto (Delegada al Repositorio)
        if (_reservaRepository.CheckConflict(reserva.LaboratorioId, reserva.FechaInicio, reserva.FechaFin))
        {
            throw new InvalidOperationException("Conflicto de horario: El laboratorio no está disponible en el período solicitado.");
        }

        // Persistir usando el método correcto
        if (reserva is ReservaCuatrimestral cuatrimestral)
        {
            _reservaRepository.AddCuatrimestral(cuatrimestral);
        }
        else if (reserva is ReservaEventual eventual)
        {
            _reservaRepository.AddEventual(eventual);
        }
        else
        {
            throw new ArgumentException("Tipo de reserva no válido.");
        }

        _reservaRepository.SaveChanges();
    }


    public void BajaReserva(int reservaId)
    {
        var reserva = _reservaRepository.GetById(reservaId);
        if (reserva == null)
        {
            throw new KeyNotFoundException($"Reserva con ID {reservaId} no encontrada.");
        }

        _reservaRepository.Remove(reserva);
        _reservaRepository.SaveChanges();
    }

    public void ModificarReserva(Reserva reservaModificada)
    {
        if (reservaModificada.FechaInicio >= reservaModificada.FechaFin)
        {
            throw new ArgumentException("La fecha de inicio debe ser anterior a la fecha de finalización.");
        }

        // Validación de Horario 
        TimeSpan horaInicio = reservaModificada.FechaInicio.TimeOfDay;
        DayOfWeek dia = reservaModificada.FechaInicio.DayOfWeek;
        if (dia == DayOfWeek.Sunday)
        {
            throw new InvalidOperationException("No se permiten reservas los Domingos.");
        }

        // 3Validación de Conflicto. Se pasa el ID de la reserva actual para que el repositorio la excluya del chequeo.
        if (_reservaRepository.CheckConflict(
                reservaModificada.LaboratorioId,
                reservaModificada.FechaInicio,
                reservaModificada.FechaFin,
                reservaModificada.ReservaId // <-- Excluye la propia reserva
            ))
        {
            throw new InvalidOperationException("Conflicto de horario: La modificación crea un solapamiento con otra reserva.");
        }

        _reservaRepository.Update(reservaModificada);
        _reservaRepository.SaveChanges();
    }


    public Reserva GetReservaParaEdicion(int id)
    {
        return _reservaRepository.GetReservaDetalle(id);
    }

    public IEnumerable<ReservaVista> ObtenerTodasReservasVista()
    {
        // Delega la proyección al Repositorio
        return _reservaRepository.GetAllReservasVista();
    }

    // Métodos Auxiliares para la UI (Delegación simple de carga de ComboBoxes)
    public List<Laboratorio> ObtenerDatosLaboratorios() => _reservaRepository.GetLaboratorios();
    public List<Profesor> ObtenerDatosProfesores() => _reservaRepository.GetProfesores();
    public List<TipoReserva> ObtenerDatosTiposReserva() => _reservaRepository.GetTiposReserva();
    public List<Carrera> ObtenerDatosCarreras() => _reservaRepository.GetCarreras();
    public List<Asignatura> ObtenerDatosAsignaturas() => _reservaRepository.GetAsignaturas();
    public List<Comision> ObtenerDatosComisiones() => _reservaRepository.GetComisiones();

}