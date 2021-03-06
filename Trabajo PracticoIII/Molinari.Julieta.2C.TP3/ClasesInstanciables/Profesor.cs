﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor() : base()
        {
           
        }

        /// <summary>
        /// constructor de clase
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido,string dni,ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Hce publicos los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Asigna de manera aleatoria dos clases al profesor
        /// </summary>
        private void  _randomClases()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            clasesDelDia.Enqueue((Universidad.EClases)(random.Next(0, 3)));
            clasesDelDia.Enqueue((Universidad.EClases)(random.Next(0, 3)));
        }

        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());            

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga operador == compara si un profesor da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool resultado = false;
            if (i.clasesDelDia.Contains(clase))
            {
                resultado = true;
            }
            return resultado;
        }

        /// <summary>
        /// Sobrecarga operador != compara si un profesor no da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Devuelve la clases del dia del profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: " );
            if (this.clasesDelDia != null)
            {
                foreach (Universidad.EClases auxClase in this.clasesDelDia)
                {
                    sb.AppendLine(auxClase.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
