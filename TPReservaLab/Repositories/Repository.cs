using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ReservaLabContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ReservaLabContext context)
    {
        // DI inyectará el contexto aquí.
        _context = context;
        _dbSet = context.Set<T>();
    }

    public T GetById(int id) => _dbSet.Find(id);
    public IEnumerable<T> GetAll() => _dbSet.ToList();
    public void Add(T entity) => _dbSet.Add(entity);
    public void Update(T entity)
    {
        // 1. Obtener la clave principal (Primary Key) del objeto entrante.
        var keyName = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();
        var keyValue = entity.GetType().GetProperty(keyName).GetValue(entity, null);

        // 2. Crear una instancia temporal de la entidad con el mismo ID.
        var existingEntry = _dbSet.Local.SingleOrDefault(e => e.GetType().GetProperty(keyName).GetValue(e, null).Equals(keyValue));

        // 3. Si existe una instancia siendo rastreada, la separamos forzadamente.
        // Esto limpia cualquier rastro de la entidad que pudo haber sido cargada por GetById o GetAll.
        if (existingEntry != null)
        {
            _context.Entry(existingEntry).State = EntityState.Detached;
        }

        // 4. Adjuntar la entidad modificada y marcar como Modified.
        // Usamos el método Update directamente, ya que realiza el Attach(Modified) de forma segura
        // siempre y cuando no haya otra instancia siendo rastreada (lo cual garantizamos en el paso 3).
        _dbSet.Update(entity);
    }
    public void Remove(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached) _dbSet.Attach(entity);
        _dbSet.Remove(entity);
    }
    public void SaveChanges() => _context.SaveChanges();
}