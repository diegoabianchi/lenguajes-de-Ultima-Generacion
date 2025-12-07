using System;
using System.Collections.Generic;
using System.Linq;
using TP_GestionVentas.Models;
using TP_GestionVentas.Repositories;

namespace TP_GestionVentas.Controllers
{
    public class CategoriaController
    {
        private readonly IRepository<Categoria> _repository;

        public CategoriaController(IRepository<Categoria> repository)
        {
            _repository = repository;
        }

        public List<Categoria> ObtenerTodas() => _repository.GetAll().ToList();

        public void GuardarCategoria(Categoria cat)
        {
            if (string.IsNullOrWhiteSpace(cat.Nombre)) throw new Exception("El nombre es obligatorio.");

            if (cat.CategoriaId == 0)
                _repository.Add(cat);
            else
                _repository.Update(cat);

            _repository.SaveChanges();
        }

        public void EliminarCategoria(int id)
        {
            var cat = _repository.GetById(id);
            if (cat != null)
            {
                _repository.Remove(cat); // Dará error si tiene productos asociados (FK Restrict)
                _repository.SaveChanges();
            }
        }
    }
}