using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TP_GestionVentas.Data;
using TP_GestionVentas.Models;

namespace TP_GestionVentas.Repositories
{
    public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(TechStoreContext context) : base(context)
        {
        }

        public IEnumerable<Vendedor> Search(string valor)
        {
            return _context.Vendedores
                .Where(v => v.NombreCompleto.Contains(valor) || (v.Email != null && v.Email.Contains(valor)))
                .OrderBy(v => v.NombreCompleto)
                .ToList();
        }

        public bool ExisteEmail(string email, int idExcluir = 0)
        {
            return _context.Vendedores.Any(v => v.Email == email && v.VendedorId != idExcluir);
        }
    }
}