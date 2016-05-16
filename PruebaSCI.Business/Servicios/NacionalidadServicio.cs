using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaSCI.Business.DTO;
using PruebaSCI.Business.Repositorios;
using PruebaSCI.Data.Entities;

namespace PruebaSCI.Business.Servicios
{
    public class NacionalidadServicio:INacioanlidadServicio
    {
        public INacionalidadRepositorio NacionalidadRepositorio { get; set; }

        public void Insertar(DTO.PaisDTO entidad)
        {
            var entity = Mapper.Map<Pais>(entidad);
           NacionalidadRepositorio.Insertar(entity);
        }

        public ICollection<DTO.PaisDTO> Todos()
        {
            return NacionalidadRepositorio.Todos().Select(Mapper.Map<PaisDTO>).ToList();
        }

        public void Borrar(Guid id)
        {
            NacionalidadRepositorio.Borrar(id);
        }

        public void Actualizar(DTO.PaisDTO entidad)
        {
            NacionalidadRepositorio.Actualizar(Mapper.Map<Pais>(entidad));
        }

        public DTO.PaisDTO ObtenerPorId(Guid id)
        {
           var pais = NacionalidadRepositorio.ObtenerPorId(id);
            return Mapper.Map<PaisDTO>(pais);
        }
    }
}
