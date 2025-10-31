
using Microsoft.EntityFrameworkCore;

public class ReservaRepository
{
    private readonly ReservaLabContext _context;

    public ReservaRepository()
    {
        _context = new ReservaLabContext();
    }

    // --- LÓGICA DE VALIDACIÓN ---
    // Método para evitar solapamientos de horario. Se incluye reservaIdToExclude para MODIFICACIÓN
    public bool CheckConflict(int laboratorioId, DateTime fechaInicio, DateTime fechaFin, int reservaIdToExclude = 0)
    {
        return _context.Reservas
            .Any(r =>
                r.ReservaId != reservaIdToExclude && // Ignora la propia reserva si estamos modificando
                r.LaboratorioId == laboratorioId &&
                r.IsActive &&
                // Condición de solapamiento: [NuevaInicio < ExistenteFin] Y [NuevaFin > ExistenteInicio]
                (fechaInicio < r.FechaFin && fechaFin > r.FechaInicio)
            );
    }

    // --- CONSULTA (READ) ---
    public List<Reserva> GetAll()
    {
        return _context.Reservas
            .Include(r => r.Profesor)
            .Include(r => r.Asignatura)
            .Include(r => r.Laboratorio)
            .ToList();
    }
    public Reserva GetById(int id)
    {
        // Se puede usar Find() para buscar por PK, o FirstOrDefault con Includes
        return _context.Reservas
            .Include(r => r.Profesor)
            .FirstOrDefault(r => r.ReservaId == id);
    }

    // --- ALTA (CREATE) ---
    public void Add(Reserva nuevaReserva)
    {
        _context.Reservas.Add(nuevaReserva);
        _context.SaveChanges();
    }

    // --- MODIFICACIÓN (UPDATE) ---
    public void Update(Reserva reservaModificada)
    {
        _context.Reservas.Update(reservaModificada);
        _context.SaveChanges();
    }

    // --- BAJA (DELETE) ---
    public void Remove(int id)
    {
        var reserva = _context.Reservas.Find(id);
        if (reserva != null)
        {
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
        }
    }

    // Consulta Por Fecha de Reserva
    public IEnumerable<Reserva> GetByDateRange(DateTime fechaInicio, DateTime fechaFin)
    {
        return _context.Reservas
                       // Incluimos las propiedades de navegación para obtener los nombres
                       .Include(r => r.Profesor)
                       .Include(r => r.Asignatura)
                       .Include(r => r.Laboratorio)
                       // Filtramos por el rango de fechas
                       .Where(r => r.FechaInicio >= fechaInicio && r.FechaFin <= fechaFin)
                       .ToList();
    }

    // Consulta Por Profesor a cargo
    public IEnumerable<Reserva> GetByProfesor(int profesorId)
    {
        return _context.Reservas
                       .Include(r => r.Profesor)
                       .Include(r => r.Asignatura)
                       .Include(r => r.Laboratorio)
                       .Where(r => r.ProfesorId == profesorId)
                       .ToList();
    }

    // Consulta Por Asignatura
    public IEnumerable<Reserva> GetByAsignatura(int asignaturaId)
    {
        return _context.Reservas
                       .Include(r => r.Profesor)
                       .Include(r => r.Asignatura)
                       .Include(r => r.Laboratorio)
                       .Where(r => r.AsignaturaId == asignaturaId)
                       .ToList();
    }

    public List<Carrera> GetCarreras()
    {
        return _context.Carreras.OrderBy(c => c.Nombre).ToList();
    }

    public List<Comision> GetComisiones()
    {
        return _context.Comisiones.OrderBy(c => c.Codigo).ToList();
    }

    public List<Laboratorio> GetLaboratorios()
    {
        // Obtener la lista de laboratorios, ordenados por número
        return _context.Laboratorios.OrderBy(l => l.Numero).ToList();
    }

    public List<Profesor> GetProfesores()
    {
        // Obtener la lista de profesores, ordenados alfabéticamente
        return _context.Profesores.OrderBy(p => p.NombreCompleto).ToList();
    }

    public List<Asignatura> GetAsignaturas()
    {
        // Obtener la lista de asignaturas, ordenadas por nombre
        return _context.Asignaturas.OrderBy(a => a.Nombre).ToList();
    }

    public List<TipoReserva> GetTiposReserva()
    {
        // Obtener los tipos de reserva (Cuatrimestral, Eventual)
        return _context.TiposReserva.ToList();
    }


    public Reserva GetReservaDetalle(int id)
    {
        // Utilizamos el DbSet de la clase base Reserva.
        // Incluimos las propiedades de navegación de las clases derivadas para que EF Core cargue la columna correspondiente de la tabla hija (TPT).

        return _context.Reservas
            .Include(r => r as ReservaCuatrimestral)
            .Include(r => r as ReservaEventual)
            .Include(r => r.Profesor)
            .Include(r => r.Laboratorio)
            .Include(r => r.Carrera)
            .Include(r => r.Asignatura)
            .Include(r => r.Comision)
            .FirstOrDefault(r => r.ReservaId == id);
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

        return reservas.Select(r => new ReservaVista
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

            Observaciones = r.Observaciones ?? "N/A",
            Activa = r.IsActive
        }).ToList();
    }
}