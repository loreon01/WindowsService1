using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1_Lorenzo_Manzo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            // Crear una instancia del servicio
            IncrementService service = new IncrementService();

            //Ejecutar el servicio
            ServiceBase.Run(service);

        }
    }
}
