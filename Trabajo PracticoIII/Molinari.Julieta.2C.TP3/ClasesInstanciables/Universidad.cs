using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{

    public class Universidad
    {
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;


        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xmlArchivo = new Xml<Universidad>();

            return xmlArchivo.Guardar("Universidad.Xml", uni);

        }

        public Universidad Leer()
        {
            Universidad uni;
            Xml<Universidad> xmlArchivo = new Xml<Universidad>();
            xmlArchivo.Leer("Universidad.Xml", out uni);

            return uni;

        }
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Jornadas: ");

            foreach (Jornada j in uni.Jornadas)
            {
                sb.AppendLine(j.ToString());
            }

            sb.AppendLine("Profesores: ");

            foreach (Profesor p in uni.profesores)
            {
                sb.AppendLine(p.ToString());
            }

            sb.AppendLine("Alumnos: ");

            foreach (Alumno a in uni.alumnos)
            {
                sb.AppendLine(a.ToString());
            }

            return sb.ToString();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool resultado = false;
            foreach (Alumno auxAlumno in g.alumnos)
            {
                if (auxAlumno == a)
                {
                    throw new AlumnoRepetidoException();
                    
                }
                    
            }

            return resultado;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool resultado = false;
            foreach (Jornada auxProfesor in g.jornada)
            {
                if (auxProfesor.Instructor == i)
                {
                    resultado = true;
                }                  
            }
            return resultado;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {

            foreach (Profesor p in u.profesores)
            {
                if (p == clase)
                {
                    return p;
                }

            }
            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {

            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            return null;
        }

        public static Universidad operator +(Universidad u, EClases clase)
        {

            Jornada jornadaNueva;
            if (u.profesores.Count == 0)
            {
                throw new SinProfesorException();
            }
            else
            {
                jornadaNueva = new Jornada(clase, u == clase);
                foreach (Alumno auxAlumno in u.alumnos)
                {
                    if (auxAlumno == clase)
                        jornadaNueva.Alumnos.Add(auxAlumno);
                }
                u.jornada.Add(jornadaNueva);

            }

            return u;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
