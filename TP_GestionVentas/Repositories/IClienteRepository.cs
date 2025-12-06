using System.Collections.Generic;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        // Búsqueda específica por Nombre o DNI
        IEnumerable<Cliente> Search(string valor);

        // Validación para evitar duplicados de DNI/CUIT
        bool ExisteDocumento(string documento, int idExcluir = 0);
    }
}