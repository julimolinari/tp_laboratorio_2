using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
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

        public bool Leer(string archivo, out string datos)
        {
            bool resultado = false;
            StreamReader reader;

            if (File.Exists(archivo))
            {
                reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
                reader.Close();
                resultado = true;
            }
            else
            {
                datos = "";
            }

            return resultado;
        }

    }
}
