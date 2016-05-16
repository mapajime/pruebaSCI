using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaSCI.Data.Context;
using PruebaSCI.Data.Entities;

namespace PruebaSCI.Business.Repositorios
{
    public class NacionalidadRepositorio : INacionalidadRepositorio
    {
        private PruebaContext _contexto;

        public NacionalidadRepositorio()
        {
            _contexto = new PruebaContext();
        }
            
        public void Insertar(Pais entidad)
        {

            if (entidad.Id == Guid.Empty)
                entidad.Id = Guid.NewGuid();
            _contexto.Paises.Add(entidad);
            _contexto.SaveChanges();
        }

        public ICollection<Pais> Todos()
        {
            return _contexto.Paises.ToList();
        }

        public void Borrar(Guid id)
        {
            var entidad = _contexto.Paises.Find(id);
            if (entidad == null)
                return;
            _contexto.Paises.Remove(entidad);
            _contexto.SaveChanges();
        }

        public void Actualizar(Pais entidad)
        {
            if(entidad == null)
                return;
           
            var e = _contexto.Paises.Find(entidad.Id);
            if(e == null)
                return;
            e.Nombre = entidad.Nombre;
            _contexto.SaveChanges();

        }

        public Pais ObtenerPorId(Guid id)
        {
            return _contexto.Paises.SingleOrDefault(x => x.Id == id);
        }
    }
}
