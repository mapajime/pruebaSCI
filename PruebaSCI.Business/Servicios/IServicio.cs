using System.Collections.Generic;

namespace PruebaSCI.Business.Servicios
{
    public interface IServicio <T, in TKey> where T : class where TKey : struct 
    {
        void Insertar(T entidad);
        ICollection<T> Todos();
        void Borrar(TKey id);
        void Actualizar(T entidad);
        T ObtenerPorId(TKey id);
    }
}
