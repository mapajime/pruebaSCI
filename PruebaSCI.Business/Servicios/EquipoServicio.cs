using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaSCI.Business.DTO;
using PruebaSCI.Business.Repositorios;
using PruebaSCI.Data.Entities;

namespace PruebaSCI.Business.Servicios
{
    public class EquipoServicio : IEquipoServicio
    {
        public IEquipoRepositorio EquipoRepositorio { get; set; }

        public void Insertar(EquipoDTO entidad)
        {
            var entity = Mapper.Map<Equipo>(entidad);
            EquipoRepositorio.Insertar(entity);
        }

        public ICollection<EquipoDTO> Todos()
        {
            return EquipoRepositorio.Todos().Select(Mapper.Map<EquipoDTO>).ToList();
        }

        public void Borrar(Guid id)
        {
            EquipoRepositorio.Borrar(id);
        }

        public void Actualizar(EquipoDTO entidad)
        {
            EquipoRepositorio.Actualizar(Mapper.Map<Equipo>(entidad));
        }

        public EquipoDTO ObtenerPorId(Guid id)
        {
            var entidad = EquipoRepositorio.ObtenerPorId(id);
            return Mapper.Map<EquipoDTO>(entidad);
        }
    }
}
