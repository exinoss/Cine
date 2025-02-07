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
    internal class dtoSala
    { // Propiedades
        public int IDSala { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public string Tipo { get; set; }

        // CRUD
        public bool Registrar(dtoSala nuevaSala)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_InsertSala", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero", nuevaSala.Numero);
                    cmd.Parameters.AddWithValue("@Capacidad", nuevaSala.Capacidad);
                    cmd.Parameters.AddWithValue("@Tipo", nuevaSala.Tipo);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la sala: {ex.Message}");
                return false;
            }
        }

        public bool Actualizar(dtoSala sala)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_UpdateSala", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDSala", sala.IDSala);
                    cmd.Parameters.AddWithValue("@Numero", sala.Numero);
                    cmd.Parameters.AddWithValue("@Capacidad", sala.Capacidad);
                    cmd.Parameters.AddWithValue("@Tipo", sala.Tipo);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la sala: {ex.Message}");
                return false;
            }
        }

        public bool Eliminar(int idSala)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_DeleteSala", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDSala", idSala);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la sala: {ex.Message}");
                return false;
            }
        }

        public List<dtoSala> LeerDatos()
        {
            var lista = new List<dtoSala>();
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_GetAllSalas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var sala = new dtoSala
                            {
                                IDSala = Convert.ToInt32(reader["IDSala"]),
                                Numero = Convert.ToInt32(reader["Numero"]),
                                Capacidad = Convert.ToInt32(reader["Capacidad"]),
                                Tipo = reader["Tipo"].ToString()
                            };
                            lista.Add(sala);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer las salas: {ex.Message}");
            }

            return lista;
        }
    }
}
