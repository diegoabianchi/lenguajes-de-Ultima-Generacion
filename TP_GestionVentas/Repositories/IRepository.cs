using System.Collections.Generic;

namespace TP_GestionVentas.Repositories
{
    public interface IRepository<T> where T : class
    {
        // Lectura
        T? GetById(int id);
        IEnumerable<T> GetAll();

        // Escritura
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);

        // Persistencia
        void SaveChanges();
    }
}