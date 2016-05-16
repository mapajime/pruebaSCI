using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSCI.Business.Repositorios
{
    public interface IRepositorio<T, in TKey>
        where T : class
        where TKey : struct
    {
        void Insertar(T entidad);
        ICollection<T> Todos();
        void Borrar(TKey id);
        void Actualizar(T entidad);
        T ObtenerPorId(TKey id);
    }
}
