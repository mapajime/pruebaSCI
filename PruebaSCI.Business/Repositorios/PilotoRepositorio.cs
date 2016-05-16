using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaSCI.Data.Entities;
using System.Configuration;
using System.Data;
using PruebaSCI.Data.Enumeraciones;

namespace PruebaSCI.Business.Repositorios
{
    public class PilotoRepositorio : IPilotoRepositorio
    {
        public string CadenaConexion
        {
            get { return ConfigurationManager.ConnectionStrings["pruebaCS"].ConnectionString; }
        }

        private SqlCommand GenerarCommand(OperacionesEnum accion, Guid? id = null, string nombre = null, int? numero = null, DateTime? fechaNacimiento = null, Guid? idEquipo = null, Guid? idPais = null)
        {
            var query = @"[dbo].[SPRealizarCambiosPilotos]";
            var comando = new SqlCommand
            {
                CommandText = query,
                CommandType = CommandType.StoredProcedure,
            };

            comando.Parameters.Add("@IdAccion", SqlDbType.Int).Value = (int)accion;
            comando.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = (object)id ?? DBNull.Value;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = (object)nombre ?? DBNull.Value;
            comando.Parameters.Add("@Numero", SqlDbType.Int).Value = (object)numero ?? DBNull.Value;
            comando.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = (object)fechaNacimiento ?? DBNull.Value;
            comando.Parameters.Add("@Equipo", SqlDbType.UniqueIdentifier).Value = (object)idEquipo ?? DBNull.Value;
            comando.Parameters.Add("@Nacionalidad", SqlDbType.UniqueIdentifier).Value = (object)idPais ?? DBNull.Value;

            return comando;
        }

        public void Insertar(Piloto entidad)
        {
            var comando = GenerarCommand(OperacionesEnum.Crear, entidad.Id == Guid.Empty ? Guid.NewGuid() : entidad.Id, entidad.Nombre, entidad.NumeroCarro, entidad.FechaNacimiento, entidad.Equipo.Id, entidad.Nacionalidad.Id);
            using (var conexion = new SqlConnection(CadenaConexion))
            using (comando)
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public ICollection<Piloto> Todos()
        {
            var comando = GenerarCommand(OperacionesEnum.Todos);
            using (var conexion = new SqlConnection(CadenaConexion))
            using (comando)
            {
                comando.Connection = conexion;
                conexion.Open();


                var reader = comando.ExecuteReader();

                var list = new List<Piloto>();


                while (reader.Read())
                {
                    var piloto = new Piloto
                    {
                        Equipo = new Equipo { Id = reader.GetGuid(4), Nombre = reader.GetString(7) },
                        Id = reader.GetGuid(0),
                        NumeroCarro = reader.GetInt32(2),
                        Nacionalidad = new Pais { Id = reader.GetGuid(5), Nombre = reader.GetString(6) },
                        FechaNacimiento = reader.GetDateTime(3),
                        Nombre = reader.GetString(1)
                    };

                    list.Add(piloto);
                }
                conexion.Close();

                return list;
            }
        }

        public void Borrar(Guid id)
        {
            var comando = GenerarCommand(OperacionesEnum.Borrar,id);
            using (var conexion = new SqlConnection(CadenaConexion))
            using (comando)
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public void Actualizar(Piloto entidad)
        {
            var comando = GenerarCommand(OperacionesEnum.Editar, entidad.Id, entidad.Nombre, entidad.NumeroCarro, entidad.FechaNacimiento, entidad.Equipo.Id, entidad.Nacionalidad.Id);
            using (var conexion = new SqlConnection(CadenaConexion))
            using (comando)
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public Piloto ObtenerPorId(Guid id)
        {
            var comando = GenerarCommand(OperacionesEnum.ObtenerPorId,id);
            using (var conexion = new SqlConnection(CadenaConexion))
            using (comando)
            {
                comando.Connection = conexion;
                conexion.Open();

                var reader = comando.ExecuteReader();

                if (!reader.HasRows)
                    return null;
                Piloto piloto = null;

                while (reader.Read())
                {
                    piloto = new Piloto
                    {
                        Equipo = new Equipo { Id = reader.GetGuid(4), Nombre = reader.GetString(7) },
                        Id = reader.GetGuid(0),
                        NumeroCarro = reader.GetInt32(2),
                        Nacionalidad = new Pais { Id = reader.GetGuid(5), Nombre = reader.GetString(6) },
                        FechaNacimiento = reader.GetDateTime(3),
                        Nombre = reader.GetString(1)
                    };
                }
                conexion.Close();
                return piloto;
            }
        }
    }
}
