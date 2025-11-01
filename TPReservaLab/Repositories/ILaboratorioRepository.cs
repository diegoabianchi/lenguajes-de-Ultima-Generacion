public interface ILaboratorioRepository : IRepository<Laboratorio>
{
    Laboratorio GetByNumero(int numero);
    bool HasActiveReservations(int laboratorioId);
}