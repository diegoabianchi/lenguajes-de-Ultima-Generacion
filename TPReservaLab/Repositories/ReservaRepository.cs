using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class ReservaRepository : Repository<Reserva>, IReservaRepository
{

    public ReservaRepository(ReservaLabContext context) : base(context)
    {
    }

    public void AddCuatrimestral(ReservaCuatrimestral reservaCuatrimestral)
    {
        _context.ReservasCuatrimestrales.Add(reservaCuatrimestral);
    }
    public void AddEventual(ReservaEventual reservaEventual)
    {
        _context.ReservasEventuales.Add(reservaEventual);
    }

    public Reserva GetReservaDetalle(int id)
    {
        var query = _context.Reservas.AsQueryable();
        query = query
            .Include(r => r.Profesor)
            .Include(r => r.Laboratorio)
            .Include(r => r.Carrera)
            .Include(r => r.Asignatura)
            .Include(r => r.Comision);

        Reserva? reserva = query
            .OfType<ReservaCuatrimestral>() // Incluye todas las Cuatrimestrales
            .Where(r => r.ReservaId == id)
            .FirstOrDefault();

        if (reserva == null)
        {
            // Si no es Cuatrimestral, busca si es Eventual.
            reserva = query
                .OfType<ReservaEventual>()
                .Where(r => r.ReservaId == id)
                .FirstOrDefault();
        }
        if (reserva == null)
        {
            // Si no es ninguna de las anteriores (lo que no debería ocurrir) al menos carga la base
            reserva = query.FirstOrDefault(r => r.ReservaId == id);
        }

        return reserva;
    }

    public bool CheckConflict(int laboratorioId, DateTime fechaInicio, DateTime fechaFin, int reservaIdToExclude = 0)
    {
        return _context.Reservas
            .Any(r =>
                r.ReservaId != reservaIdToExclude && // Excluye la reserva que estamos modificando
                r.LaboratorioId == laboratorioId &&
                r.IsActive &&
                // Condición de solapamiento
                (fechaInicio < r.FechaFin && fechaFin > r.FechaInicio)
            );
    }


    public IEnumerable<Reserva> GetByDateRange(DateTime fechaInicio, DateTime fechaFin)
    {
        return _context.Reservas
                       .Include(r => r.Profesor)
                       .Include(r => r.Laboratorio)
                       .Where(r => r.FechaInicio >= fechaInicio && r.FechaFin <= fechaFin)
                       .ToList();
    }
    public IEnumerable<Reserva> GetByProfesor(int profesorId)
    {
        return _context.Reservas
                       .Include(r => r.Profesor)
                       .Include(r => r.Asignatura)
                       .Include(r => r.Laboratorio)
                       .Where(r => r.ProfesorId == profesorId)
                       .ToList();
    }
    public IEnumerable<Reserva> GetByAsignatura(int asignaturaId)
    {
        return _context.Reservas
                       .Include(r => r.Profesor)
                       .Include(r => r.Asignatura)
                       .Include(r => r.Laboratorio)
                       .Where(r => r.AsignaturaId == asignaturaId)
                       .ToList();
    }

    public List<Laboratorio> GetLaboratorios()
    {
        return _context.Laboratorios.OrderBy(l => l.Numero).ToList();
    }
    public List<Profesor> GetProfesores()
    {
        return _context.Profesores.OrderBy(p => p.NombreCompleto).ToList();
    }
    public List<Carrera> GetCarreras()
    {
        return _context.Carreras.OrderBy(c => c.Nombre).ToList();
    }
    public List<Comision> GetComisiones()
    {
        return _context.Comisiones.OrderBy(c => c.Codigo).ToList();
    }
    public List<Asignatura> GetAsignaturas()
    {
        return _context.Asignaturas.OrderBy(a => a.Nombre).ToList();
    }
    public List<TipoReserva> GetTiposReserva()
    {
        return _context.TiposReserva.ToList();
    }


    public IEnumerable<ReservaVista> GetAllReservasVista()
    {
        var reservas = _context.Reservas
            .Include(r => r.Profesor)
            .Include(r => r.Asignatura)
            .Include(r => r.Laboratorio)
            .Include(r => r.TipoReserva)
            .Include(r => r.Carrera)
            .Include(r => r.Comision)
            .ToList();

        return reservas.Select(r =>
        {
            // Intentar hacer el casting a los tipos derivados
            var cuatrimestral = r as ReservaCuatrimestral;
            var eventual = r as ReservaEventual;

            return new ReservaVista
            {
                ReservaId = r.ReservaId,
                TipoReserva = r.TipoReserva.Codigo,
                Inicio = r.FechaInicio,
                Fin = r.FechaFin,
                Laboratorio = r.Laboratorio.Numero.ToString(),
                Profesor = r.Profesor.NombreCompleto,
                Asignatura = r.Asignatura.Nombre,
                Carrera = r.Carrera.Nombre,
                Comision = r.Comision.Codigo,
                Frecuencia = cuatrimestral != null ? cuatrimestral.Frecuencia : "", // Solo si es Cuatrimestral
                CantidadSemanas = eventual != null ? (int?)eventual.CantidadSemanas : null, // Solo si es Eventual
                Observaciones = r.Observaciones ?? "N/A",
                Activa = r.IsActive
            };
        }).ToList();
    }
}