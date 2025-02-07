using Cine.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Controlador
{
    internal class clsFuncion
    {
        private dtoFuncion _modelo = new dtoFuncion();

        public bool Registrar(dtoFuncion nuevaFuncion)
        {
            try
            {
                return _modelo.Registrar(nuevaFuncion);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsFuncion -> Registrar: {ex.Message}");
                return false;
            }
        }

        public bool Actualizar(dtoFuncion funcion)
        {
            try
            {
                return _modelo.Actualizar(funcion);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsFuncion -> Actualizar: {ex.Message}");
                return false;
            }
        }

        public bool Eliminar(int idFuncion)
        {
            try
            {
                return _modelo.Eliminar(idFuncion);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsFuncion -> Eliminar: {ex.Message}");
                return false;
            }
        }

        public List<dtoFuncion> LeerDatos()
        {
            try
            {
                return _modelo.LeerDatos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsFuncion -> LeerDatos: {ex.Message}");
                return new List<dtoFuncion>();
            }
        }
    }
}
