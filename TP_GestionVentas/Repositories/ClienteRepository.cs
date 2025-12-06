using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TP_GestionVentas.Data;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(TechStoreContext context) : base(context)
        {
        }

        public IEnumerable<Cliente> Search(string valor)
        {
            return _context.Clientes
                .Where(c => c.NombreCompleto.Contains(valor) || (c.CUIT_DNI != null && c.CUIT_DNI.Contains(valor)))
                .OrderBy(c => c.NombreCompleto)
                .ToList();
        }

        public bool ExisteDocumento(string documento, int idExcluir = 0)
        {
            // Verifica si hay otro cliente con el mismo documento, excluyendo al actual si es edición
            return _context.Clientes.Any(c => c.CUIT_DNI == documento && c.ClienteId != idExcluir);
        }
    }
}