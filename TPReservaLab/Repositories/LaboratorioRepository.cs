using System.Linq;

public class LaboratorioRepository : Repository<Laboratorio>, ILaboratorioRepository
{
    public LaboratorioRepository(ReservaLabContext context) : base(context)
    {
    }

    public Laboratorio GetByNumero(int numero)
    {
        return _dbSet.FirstOrDefault(l => l.Numero == numero);
    }

    public bool HasActiveReservations(int laboratorioId)
    {
        // Usa el DbSet de Reservas a través del contexto inyectado
        return _context.Reservas.Any(r => r.LaboratorioId == laboratorioId && r.IsActive);
    }
}