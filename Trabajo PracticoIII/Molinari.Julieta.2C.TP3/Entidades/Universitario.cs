using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        /// <summary>
        /// Propiedad para legajo
        /// </summary>
        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }

        }

        /// <summary>
        /// Constrcutor por defecto
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
            :base (nombre,apellido,dni,nacionalidad)
        {
            this.Legajo = legajo;
        }
        /// <summary>
        /// Retorna los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO NÚMERO: {0} \n" ,this.Legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Firma de metodo abstracto 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();   
        
         
        /// <summary>
        /// Metodo para validar si un objeto es universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }

        /// <summary>
        /// Sobrecarga de operador == para comparar universitarios
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool resultado = false;
            if (pg1.Equals(pg2) && pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                resultado = true;
            }
            return resultado;
        }

        /// <summary>
        /// Sobrecarga de operador != para distinguir universitarios
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


    }
}
