using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PruebaSCI.Business.DTO;
using PruebaSCI.Business.Repositorios;
using PruebaSCI.Data.Entities;

namespace PruebaSCI.Business.Servicios
{
    public class PilotoServicio:IPilotoServicio
    {
        public IPilotoRepositorio PilotoRepositorio { get; set; }

        public void Insertar(DTO.PilotoDTO entidad)
        {
            PilotoRepositorio.Insertar(Mapper.Map<Piloto>(entidad));
        }

        public ICollection<DTO.PilotoDTO> Todos()
        {
            return PilotoRepositorio.Todos().Select(Mapper.Map<PilotoDTO>).ToList();
        }

        public void Borrar(Guid id)
        {
            PilotoRepositorio.Borrar(id);
        }

        public void Actualizar(DTO.PilotoDTO entidad)
        {
            PilotoRepositorio.Actualizar(Mapper.Map<Piloto>(entidad));
        }

        public PilotoDTO ObtenerPorId(Guid id)
        {
            return Mapper.Map<PilotoDTO>(PilotoRepositorio.ObtenerPorId(id));
        }
    }
}
