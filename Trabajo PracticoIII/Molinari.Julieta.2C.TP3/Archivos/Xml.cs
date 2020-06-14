using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml <T> : IArchivo<T>
    {
        /// <summary>
        /// Genera un archivo xml y guarda los datos en el path pedido
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool resultado = false;

            if (archivo != null && datos != null)
            {
                XmlTextWriter writer;
                XmlSerializer ser;


                writer = new XmlTextWriter(archivo, Encoding.UTF8);

                ser = new XmlSerializer(typeof(T));

                ser.Serialize(writer, datos);

                writer.Close();

                resultado = true;

            }


            return resultado;
        }

        /// <summary>
        /// Lee un archivo xml del path pasado por parametros
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool resultado = false;
            XmlTextReader reader;
            XmlSerializer ser;
            datos = default(T);

            if (File.Exists(archivo))
            {
                reader = new XmlTextReader(archivo);                
                ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                reader.Close();
                resultado = true;
            }else
            {
                throw new ArchivosException(new Exception());
            }

            return resultado;
           
        }
    }
}
