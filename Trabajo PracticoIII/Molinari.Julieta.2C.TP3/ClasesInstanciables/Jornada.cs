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
      
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        
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

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public static string Leer()
        {
            string aux;
            Texto archivoLeer = new Texto();
            archivoLeer.Leer("Jornada.txt", out aux);
            return aux;
           
        }

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
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE: " + this.clase);
            sb.AppendLine("INSTRUCTOR: " + this.instructor);
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos) 
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

    }
}
