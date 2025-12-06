using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TP_GestionVentas.Models;
using TP_GestionVentas.Repositories;

namespace TP_GestionVentas.Controllers
{
    public class ClienteController
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // --- LECTURA ---
        public List<Cliente> ObtenerTodos()
        {
            return _clienteRepository.GetAll().OrderBy(c => c.NombreCompleto).ToList();
        }
        public List<Cliente> BuscarClientes(string busqueda)
        {
            return _clienteRepository.Search(busqueda).ToList();
        }
        public Cliente? ObtenerPorId(int id)
        {
            return _clienteRepository.GetById(id);
        }

        // --- ESCRITURA ---
        public void CrearCliente(Cliente cliente)
        {
            ValidarCliente(cliente);

            // DNI debe ser único
            if (!string.IsNullOrEmpty(cliente.CUIT_DNI) && _clienteRepository.ExisteDocumento(cliente.CUIT_DNI))
            {
                throw new Exception("El DNI/CUIT ingresado ya pertenece a otro cliente.");
            }

            _clienteRepository.Add(cliente);
            _clienteRepository.SaveChanges();
        }
        public void ModificarCliente(Cliente cliente)
        {
            ValidarCliente(cliente);

            // DNI debe ser único (excluyendo al propio cliente que se edita)
            if (!string.IsNullOrEmpty(cliente.CUIT_DNI) && _clienteRepository.ExisteDocumento(cliente.CUIT_DNI, cliente.ClienteId))
            {
                throw new Exception("El DNI/CUIT ingresado ya pertenece a otro cliente.");
            }

            _clienteRepository.Update(cliente);
            _clienteRepository.SaveChanges();
        }
        public void EliminarCliente(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente != null)
            {
                _clienteRepository.Remove(cliente);
                _clienteRepository.SaveChanges();
            }
        }

        // Validaciones
        private void ValidarCliente(Cliente c)
        {
            if (string.IsNullOrWhiteSpace(c.NombreCompleto))
                throw new Exception("El nombre completo es obligatorio.");

            if (string.IsNullOrWhiteSpace(c.TipoCliente))
                throw new Exception("Debe seleccionar un tipo de cliente (Minorista/Mayorista).");

            // Validación de Email
            if (!string.IsNullOrWhiteSpace(c.Email))
            {
                // Regex: algo + @ + algo + . + algo
                string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(c.Email, patronEmail))
                {
                    throw new Exception("El formato del email no es válido (ejemplo: usuario@dominio.com).");
                }
            }

            // Validación de CUIT/DNI numérico 
            if (!string.IsNullOrWhiteSpace(c.CUIT_DNI))
            {
                if (!c.CUIT_DNI.All(char.IsDigit))
                {
                    throw new Exception("El CUIT/DNI debe contener solo números.");
                }
            }
        }
    }
}