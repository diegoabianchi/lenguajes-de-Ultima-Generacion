using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TP_GestionVentas.Data;

namespace TP_GestionVentas.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TechStoreContext _context;
        protected readonly DbSet<T> _dbSet;

        // Inyección de Dependencias del Contexto
        public Repository(TechStoreContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            // LÓGICA PARA EVITAR ERRORES DE TRACKING EN WINFORMS
            // 1. Obtener la clave primaria de la entidad entrante
            var keyName = _context.Model.FindEntityType(typeof(T))?
                .FindPrimaryKey()?.Properties
                .Select(x => x.Name).Single();

            if (keyName != null)
            {
                var keyValue = entity.GetType().GetProperty(keyName)?.GetValue(entity, null);

                if (keyValue != null)
                {
                    // 2. Buscar si hay una entidad con esa clave ya cargada en la memoria local
                    var existingEntry = _dbSet.Local.SingleOrDefault(e =>
                        e.GetType().GetProperty(keyName).GetValue(e, null).Equals(keyValue));

                    // 3. Si existe, la desconectamos para que no choque con la nueva
                    if (existingEntry != null)
                    {
                        _context.Entry(existingEntry).State = EntityState.Detached;
                    }
                }
            }

            // 4. Adjuntar y marcar como modificada
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            // Aseguramos que la entidad esté adjunta antes de borrarla
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}