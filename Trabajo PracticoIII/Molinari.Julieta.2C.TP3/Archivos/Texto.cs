using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Genera un archivo txt y guarda los datos en el path pedido
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar (string archivo, string datos)
        {
            bool resultado = false;
            if (archivo != null && datos != null)
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.Write(datos);
                    resultado = true;
                }
            }
            return resultado;            
        }

        /// <summary>
        /// Lee un archivo txt del path pasado por parametros
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool resultado = false;
            StreamReader reader;
            datos = "";
            
                if (File.Exists(archivo))
                {
                    reader = new StreamReader(archivo);
                    datos = reader.ReadToEnd();
                    reader.Close();
                    resultado = true;
            }
            else
            {
                throw new ArchivosException(new Exception());
            }
           
           
            
            return resultado;
        }

    }
}
