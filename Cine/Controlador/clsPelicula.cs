using Cine.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Controlador
{
    internal class clsPelicula
    {
        private dtoPelicula _modelo = new dtoPelicula();

        public bool Registrar(dtoPelicula nuevaPelicula)
        {
            try
            {
                return _modelo.Registrar(nuevaPelicula);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsPelicula -> Registrar: {ex.Message}");
                return false;
            }
        }

        public bool Actualizar(dtoPelicula pelicula)
        {
            try
            {
                return _modelo.Actualizar(pelicula);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsPelicula -> Actualizar: {ex.Message}");
                return false;
            }
        }

        public bool Eliminar(int idPelicula)
        {
            try
            {
                return _modelo.Eliminar(idPelicula);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsPelicula -> Eliminar: {ex.Message}");
                return false;
            }
        }

        public List<dtoPelicula> LeerDatos()
        {
            try
            {
                return _modelo.LeerDatos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsPelicula -> LeerDatos: {ex.Message}");
                return new List<dtoPelicula>(); // Retornar lista vacía si falla
            }
        }
    }
}
