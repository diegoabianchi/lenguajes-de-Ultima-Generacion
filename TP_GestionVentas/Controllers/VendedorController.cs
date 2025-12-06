using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TP_GestionVentas.Models;
using TP_GestionVentas.Repositories;

namespace TP_GestionVentas.Controllers
{
    public class VendedorController
    {
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorController(IVendedorRepository vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
        }

        // --- LECTURA ---
        public List<Vendedor> ObtenerTodos()
        {
            return _vendedorRepository.GetAll().OrderBy(v => v.NombreCompleto).ToList();
        }
        public List<Vendedor> BuscarVendedores(string busqueda)
        {
            return _vendedorRepository.Search(busqueda).ToList();
        }
        public Vendedor? ObtenerPorId(int id)
        {
            return _vendedorRepository.GetById(id);
        }

        // --- ESCRITURA ---
        public void CrearVendedor(Vendedor vendedor)
        {
            ValidarVendedor(vendedor);

            if (!string.IsNullOrWhiteSpace(vendedor.Email) && _vendedorRepository.ExisteEmail(vendedor.Email))
            {
                throw new Exception("El email ya está registrado por otro vendedor.");
            }

            _vendedorRepository.Add(vendedor);
            _vendedorRepository.SaveChanges();
        }
        public void ModificarVendedor(Vendedor vendedor)
        {
            ValidarVendedor(vendedor);

            if (!string.IsNullOrWhiteSpace(vendedor.Email) && _vendedorRepository.ExisteEmail(vendedor.Email, vendedor.VendedorId))
            {
                throw new Exception("El email ya está registrado por otro vendedor.");
            }

            _vendedorRepository.Update(vendedor);
            _vendedorRepository.SaveChanges();
        }
        public void EliminarVendedor(int id)
        {
            // Si el vendedor tiene ventas, EF Core lanzará error por FK (Restrict)
            var vendedor = _vendedorRepository.GetById(id);
            if (vendedor != null)
            {
                _vendedorRepository.Remove(vendedor);
                _vendedorRepository.SaveChanges();
            }
        }

        private void ValidarVendedor(Vendedor v)
        {
            if (string.IsNullOrWhiteSpace(v.NombreCompleto))
                throw new Exception("El nombre completo es obligatorio.");

            if (!string.IsNullOrWhiteSpace(v.Email))
            {
                string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(v.Email, patronEmail))
                {
                    throw new Exception("El formato del email no es válido.");
                }
            }
        }
    }
}