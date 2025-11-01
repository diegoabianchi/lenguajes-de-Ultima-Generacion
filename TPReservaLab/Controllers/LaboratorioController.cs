using System.Collections.Generic;
using System.Linq;

public class LaboratorioController
{
    private readonly ILaboratorioRepository _laboratorioRepository;

    public LaboratorioController(ILaboratorioRepository laboratorioRepository)
    {
        _laboratorioRepository = laboratorioRepository;
    }


    public List<Laboratorio> ObtenerTodos()
    {
        // El controlador simplemente delega la consulta al repositorio
        return _laboratorioRepository.GetAll().ToList();
    }

    public void CrearLaboratorio(Laboratorio nuevoLab)
    {
        // El número de laboratorio debe ser único
        if (_laboratorioRepository.GetByNumero(nuevoLab.Numero) != null)
        {
            throw new InvalidOperationException($"Ya existe un laboratorio con el número {nuevoLab.Numero}.");
        }
        // Capacidad positiva
        if (nuevoLab.CapacidadPuestos <= 0)
        {
            throw new InvalidOperationException("La capacidad de puestos debe ser positiva.");
        }

        _laboratorioRepository.Add(nuevoLab);
        _laboratorioRepository.SaveChanges();
    }

    public void ModificarLaboratorio(Laboratorio labModificado)
    {
        // El número no debe colisionar con otro ID
        var labExistenteConMismoNumero = _laboratorioRepository.GetByNumero(labModificado.Numero);

        if (labExistenteConMismoNumero != null && labExistenteConMismoNumero.LaboratorioId != labModificado.LaboratorioId)
        {
            throw new InvalidOperationException($"Ya existe otro laboratorio con el número {labModificado.Numero}.");
        }
        // Capacidad positiva
        if (labModificado.CapacidadPuestos <= 0)
        {
            throw new InvalidOperationException("La capacidad de puestos debe ser positiva.");
        }

        _laboratorioRepository.Update(labModificado);
        _laboratorioRepository.SaveChanges();
    }

    public void EliminarLaboratorio(int laboratorioId)
    {
        var lab = _laboratorioRepository.GetById(laboratorioId);

        if (lab == null)
        {
            throw new KeyNotFoundException($"Laboratorio con ID {laboratorioId} no encontrado.");
        }

        // No se podrá eliminar un laboratorio si tiene reservas asignadas
        if (_laboratorioRepository.HasActiveReservations(laboratorioId))
        {
            throw new InvalidOperationException($"No se puede eliminar el laboratorio {lab.Numero}. Tiene reservas activas asignadas.");
        }

        _laboratorioRepository.Remove(lab);
        _laboratorioRepository.SaveChanges();
    }
}