using System.Collections.Generic;

public interface IReservaRepository : IRepository<Reserva> // Hereda el CRUD básico
{
    // Operaciones de ALTA (CREATE) que manejan la herencia
    void AddCuatrimestral(ReservaCuatrimestral reservaCuatrimestral);
    void AddEventual(ReservaEventual reservaEventual);

    // Validación
    bool CheckConflict(int laboratorioId, DateTime fechaInicio, DateTime fechaFin, int reservaIdToExclude = 0);


    IEnumerable<Reserva> GetByDateRange(DateTime fechaInicio, DateTime fechaFin);
    IEnumerable<Reserva> GetByProfesor(int profesorId);
    IEnumerable<Reserva> GetByAsignatura(int asignaturaId);

    Reserva GetReservaDetalle(int id);

    // Método para obtener la lista proyectada (ViewModel) para la DataGridView
    IEnumerable<ReservaVista> GetAllReservasVista();

    // Métodos auxiliares para llenar ComboBoxes
    List<Laboratorio> GetLaboratorios();
    List<Profesor> GetProfesores();
    List<TipoReserva> GetTiposReserva();
    List<Carrera> GetCarreras();
    List<Asignatura> GetAsignaturas();
    List<Comision> GetComisiones();
}