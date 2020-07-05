using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;
      
        /// <summary>
        /// Propiedad Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }


        /// <summary>
        /// Propiedad Clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// Propiedad Instructor
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        

        /// <summary>
        /// Guarda los datos de la jornada en un archivo txt localizado en el C:/
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool resultado = false;
            Texto archivoTexto = new Texto();

            if (archivoTexto.Guardar("Jornada.txt",jornada.ToString()))
            {
                resultado = true;
            }

            return resultado;
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Lee los datos de un archivo txt que contiene una jornada
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string aux;
            Texto archivoLeer = new Texto();
            archivoLeer.Leer("C://Jornada.txt", out aux);
            return aux;
           
        }

        /// <summary>
        /// Sobrecarga operador == compara si un alumno participa en la clase de la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            bool resultado = false;
            foreach (Alumno auxAlumno in j.alumnos)
            {
                if (auxAlumno == a)
                    resultado = true;
            }
            return resultado;
        }

        /// <summary>
        /// Sobrecarga operador == compara si un alumno no participa en la clase de la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Sobregarga operador + agrega alumnos a la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Devuelve todos los datos de una jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}" ,this.clase , this.instructor);            
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos) 
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<-------------------------------------------------------------------------->");
            return sb.ToString();
        }

    }
}
