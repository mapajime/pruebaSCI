using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaSCI.Data.Context;
using PruebaSCI.Data.Entities;

namespace PruebaSCI.Business.Repositorios
{
    public class EquipoRepositorio : IEquipoRepositorio
    {
        private PruebaContext _contexto;

        public EquipoRepositorio()
        {
            _contexto = new PruebaContext();
        }

        public void Insertar(Equipo entidad)
        {
            if (entidad.Id == Guid.Empty)
                entidad.Id = Guid.NewGuid();
            _contexto.Equipos.Add(entidad);
            _contexto.SaveChanges();
        }

        public ICollection<Equipo> Todos()
        {
            return _contexto.Equipos.ToList();
        }

        public void Borrar(Guid id)
        {
            var entity = _contexto.Equipos.Find(id);
            if (entity == null)
                return;
            _contexto.Equipos.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Actualizar(Equipo entidad)
        {
            if (entidad == null)
                return;
            var entity = _contexto.Equipos.Find(entidad.Id);
            if (entity == null)
                return;

            entity.Nombre = entidad.Nombre;

            _contexto.SaveChanges();
        }

        public Equipo ObtenerPorId(Guid id)
        {
            return _contexto.Equipos.SingleOrDefault(p => p.Id == id);
        }
    }
}
