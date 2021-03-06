﻿using System;
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


        /// <summary>
        /// Propiedad Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad Instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Propiedad Jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Propiedad jornada indexada
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        /// <summary>
        /// Guarda los datos de la universidad en un archivo xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xmlArchivo = new Xml<Universidad>();

            return xmlArchivo.Guardar("C://Universidad.Xml", uni);

        }

        /// <summary>
        /// Lee los datos de la universidad de un archivo xml
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad uni;
            Xml<Universidad> xmlArchivo = new Xml<Universidad>();
            xmlArchivo.Leer("C://Universidad.Xml", out uni);

            return uni;

        }

        /// <summary>
        /// Devuelve los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sobrecarga operador == se fija si un alumno esta en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Sobrecarga operador != se fija si un alumno no esta en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga operador == se fija si un profesor esta en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sobrecarga operador != se fija si un profesor no esta en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga operador == retorna el 1er profesor capaz de dar esa clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna el 1er profesor que no puede dar esa clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sobre carga + agrega una clase a la universidad, generando una nueva jornada
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Agrega alumnos a la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Agrega profesores a la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }


        /// <summary>
        /// Hace publicos los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Enumerado con las clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
