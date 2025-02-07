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
    internal class dtoPelicula
    { // Propiedades que mapean la tabla Pelicula
        public int IDPelicula { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Duracion { get; set; }
        public string Clasificacion { get; set; }

        // Constructor(s) opcionales
        public dtoPelicula() { }

        // CRUD

        // 1. Registrar
        public bool Registrar(dtoPelicula nuevaPelicula)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_InsertPelicula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Titulo", nuevaPelicula.Titulo);
                    cmd.Parameters.AddWithValue("@Genero", nuevaPelicula.Genero);
                    cmd.Parameters.AddWithValue("@Duracion", nuevaPelicula.Duracion);
                    cmd.Parameters.AddWithValue("@Clasificacion", nuevaPelicula.Clasificacion);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la película: {ex.Message}");
                return false;
            }
        }

        // 2. Actualizar
        public bool Actualizar(dtoPelicula pelicula)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_UpdatePelicula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPelicula", pelicula.IDPelicula);
                    cmd.Parameters.AddWithValue("@Titulo", pelicula.Titulo);
                    cmd.Parameters.AddWithValue("@Genero", pelicula.Genero);
                    cmd.Parameters.AddWithValue("@Duracion", pelicula.Duracion);
                    cmd.Parameters.AddWithValue("@Clasificacion", pelicula.Clasificacion);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la película: {ex.Message}");
                return false;
            }
        }

        // 3. Eliminar
        public bool Eliminar(int idPelicula)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_DeletePelicula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPelicula", idPelicula);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la película: {ex.Message}");
                return false;
            }
        }

        // 4. LeerDatos
        public List<dtoPelicula> LeerDatos()
        {
            var lista = new List<dtoPelicula>();
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_GetAllPeliculas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pelicula = new dtoPelicula
                            {
                                IDPelicula = Convert.ToInt32(reader["IDPelicula"]),
                                Titulo = reader["Titulo"].ToString(),
                                Genero = reader["Genero"].ToString(),
                                Duracion = Convert.ToInt32(reader["Duracion"]),
                                Clasificacion = reader["Clasificacion"].ToString()
                            };
                            lista.Add(pelicula);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer las películas: {ex.Message}");
            }

            return lista;
        }
    }
}
