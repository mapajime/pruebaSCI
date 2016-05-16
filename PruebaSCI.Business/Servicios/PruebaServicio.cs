using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaSCI.Business.DTO;

namespace PruebaSCI.Business.Servicios
{
    public class PruebaServicio : INacioanlidadServicio
    {
        public void Insertar(PaisDTO entidad)
        {

        }

        public ICollection<PaisDTO> Todos()
        {
            return new List<PaisDTO> { new PaisDTO { Id = Guid.NewGuid(), Nombre = "Jimena" } };
        }

        public void Borrar(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(PaisDTO entidad)
        {
            throw new NotImplementedException();
        }

        public PaisDTO ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
