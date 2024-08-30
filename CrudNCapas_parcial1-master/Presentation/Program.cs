using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); //Llama al método EnableVisualStyles de la clase Application. Esto habilita los estilos visuales de Windows XP y posteriores para los formularios de la aplicación, lo que permite que los controles de los formularios tengan una apariencia más moderna y consistente con el sistema operativo
            Application.SetCompatibleTextRenderingDefault(false); //Llama al método SetCompatibleTextRenderingDefault de la clase Application con el valor false. Esto configura la aplicación para usar el renderizado de texto GDI+ en lugar del renderizado basado en GDI, proporcionando una mejor calidad de texto en los controles del formulario
            Application.Run(new Form1()); //Llama al método Run de la clase Application, que inicia el bucle de mensajes de la aplicación y muestra el formulario principal (Form1)
        }
    }
}
