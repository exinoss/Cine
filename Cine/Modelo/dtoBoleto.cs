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
    internal class dtoBoleto
    {
        public int IDBoleto { get; set; }
        public int IDFuncion { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }

        // CRUD
        public bool Registrar(dtoBoleto nuevoBoleto)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_InsertBoleto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDFuncion", nuevoBoleto.IDFuncion);
                    cmd.Parameters.AddWithValue("@Precio", nuevoBoleto.Precio);
                    cmd.Parameters.AddWithValue("@Estado", nuevoBoleto.Estado);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el boleto: {ex.Message}");
                return false;
            }
        }

        public bool Actualizar(dtoBoleto boleto)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_UpdateBoleto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDBoleto", boleto.IDBoleto);
                    cmd.Parameters.AddWithValue("@IDFuncion", boleto.IDFuncion);
                    cmd.Parameters.AddWithValue("@Precio", boleto.Precio);
                    cmd.Parameters.AddWithValue("@Estado", boleto.Estado);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el boleto: {ex.Message}");
                return false;
            }
        }

        public bool Eliminar(int idBoleto)
        {
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_DeleteBoleto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDBoleto", idBoleto);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el boleto: {ex.Message}");
                return false;
            }
        }

        public List<dtoBoleto> LeerDatos()
        {
            var lista = new List<dtoBoleto>();
            try
            {
                using (var cn = Conexion.GetConnection())
                using (var cmd = new SqlCommand("sp_GetAllBoletos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var boleto = new dtoBoleto
                            {
                                IDBoleto = Convert.ToInt32(reader["IDBoleto"]),
                                IDFuncion = Convert.ToInt32(reader["IDFuncion"]),
                                Precio = Convert.ToDecimal(reader["Precio"]),
                                Estado = reader["Estado"].ToString()
                            };
                            lista.Add(boleto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer los boletos: {ex.Message}");
            }

            return lista;
        }
    }
}
