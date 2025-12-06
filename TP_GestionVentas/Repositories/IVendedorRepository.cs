using System.Collections.Generic;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Repositories
{
    public interface IVendedorRepository : IRepository<Vendedor>
    {
        IEnumerable<Vendedor> Search(string valor);
        bool ExisteEmail(string email, int idExcluir = 0);
    }
}