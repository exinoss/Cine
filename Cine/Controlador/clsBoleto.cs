using Cine.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Controlador
{
    internal class clsBoleto
    {
        private dtoBoleto _modelo = new dtoBoleto();

        public bool Registrar(dtoBoleto nuevoBoleto)
        {
            try
            {
                return _modelo.Registrar(nuevoBoleto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsBoleto -> Registrar: {ex.Message}");
                return false;
            }
        }

        public bool Actualizar(dtoBoleto boleto)
        {
            try
            {
                return _modelo.Actualizar(boleto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsBoleto -> Actualizar: {ex.Message}");
                return false;
            }
        }

        public bool Eliminar(int idBoleto)
        {
            try
            {
                return _modelo.Eliminar(idBoleto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsBoleto -> Eliminar: {ex.Message}");
                return false;
            }
        }

        public List<dtoBoleto> LeerDatos()
        {
            try
            {
                return _modelo.LeerDatos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en clsBoleto -> LeerDatos: {ex.Message}");
                return new List<dtoBoleto>();
            }
        }
    }
}
