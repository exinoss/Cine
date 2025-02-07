using Cine.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Controlador
{
    internal class clsSala
    {
        private dtoSala _modelo = new dtoSala();

        public bool Registrar(dtoSala nuevaSala)
        {
            try
            {
                return _modelo.Registrar(nuevaSala);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsSala -> Registrar: {ex.Message}");
                return false;
            }
        }

        public bool Actualizar(dtoSala sala)
        {
            try
            {
                return _modelo.Actualizar(sala);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsSala -> Actualizar: {ex.Message}");
                return false;
            }
        }

        public bool Eliminar(int idSala)
        {
            try
            {
                return _modelo.Eliminar(idSala);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsSala -> Eliminar: {ex.Message}");
                return false;
            }
        }

        public List<dtoSala> LeerDatos()
        {
            try
            {
                return _modelo.LeerDatos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsSala -> LeerDatos: {ex.Message}");
                return new List<dtoSala>();
            }
        }
    }
}
