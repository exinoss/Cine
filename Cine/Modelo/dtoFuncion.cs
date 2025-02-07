using Cine.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Modelo
{
    internal class dtoFuncion
    {
        public int IDFuncion { get; set; }
        public int IDPelicula { get; set; }
        public int IDSala { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora { get; set; }

        // CRUD
        public bool Registrar(dtoFuncion nuevaFuncion)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_InsertFuncion", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPelicula", nuevaFuncion.IDPelicula);
                    cmd.Parameters.AddWithValue("@IDSala", nuevaFuncion.IDSala);
                    cmd.Parameters.AddWithValue("@Fecha", nuevaFuncion.Fecha);
                    cmd.Parameters.AddWithValue("@Hora", nuevaFuncion.Hora);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la función: {ex.Message}");
                return false;
            }
        }

        public bool Actualizar(dtoFuncion funcion)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_UpdateFuncion", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDFuncion", funcion.IDFuncion);
                    cmd.Parameters.AddWithValue("@IDPelicula", funcion.IDPelicula);
                    cmd.Parameters.AddWithValue("@IDSala", funcion.IDSala);
                    cmd.Parameters.AddWithValue("@Fecha", funcion.Fecha);
                    cmd.Parameters.AddWithValue("@Hora", funcion.Hora);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la función: {ex.Message}");
                return false;
            }
        }

        public bool Eliminar(int idFuncion)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_DeleteFuncion", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDFuncion", idFuncion);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la función: {ex.Message}");
                return false;
            }
        }

        public List<dtoFuncion> LeerDatos()
        {
            var lista = new List<dtoFuncion>();
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_GetAllFunciones", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var funcion = new dtoFuncion
                            {
                                IDFuncion = Convert.ToInt32(reader["IDFuncion"]),
                                IDPelicula = Convert.ToInt32(reader["IDPelicula"]),
                                IDSala = Convert.ToInt32(reader["IDSala"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Hora = Convert.ToInt32(reader["Hora"])
                            };
                            lista.Add(funcion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer las funciones: {ex.Message}");
            }

            return lista;
        }
    }
}
