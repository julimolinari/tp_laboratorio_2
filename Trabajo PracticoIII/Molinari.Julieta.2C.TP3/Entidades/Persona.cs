using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        string nombre;
        string apellido;
        ENacionalidad nacionalidad;
        int dni;

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Persona()
        {
            this.apellido = "";
            this.nombre = "";
            this.dni = 0;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre,string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            :this (nombre,apellido,nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this (nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }


        /// <summary>
        /// Propiedad Nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set {
                    if (ValidarNombreApellido(this.nombre))
                    {
                        this.nombre = value;
                    }
                    else
                        this.nombre = null;                    
                }
        }

        /// <summary>
        /// Propiedad Apellido
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                if (ValidarNombreApellido(this.apellido))
                {
                    this.apellido = value;
                }
                else
                    this.apellido = null;
            }
        }

        /// <summary>
        /// Propiedad Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value;}
        }

        /// <summary>
        /// Propiedad Dni de tipo int
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }

        /// <summary>
        /// Propiedad Dni de tipo string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Validacion de nombre y apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private bool ValidarNombreApellido(string dato)
        {
            bool resultado = false;
            if (dato.All(char.IsLetter))
            {
                resultado = true;
            }
            return resultado;
        }
        /// <summary>
        /// Valida el Dni enviado como string
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Valida el Dni enviado como int
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxDni = 0;
            if (int.TryParse(dato, out auxDni) && auxDni > 0 && auxDni <= 99999999)
            {
                if (nacionalidad == ENacionalidad.Argentino && auxDni > 89999999)
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
                if (nacionalidad == ENacionalidad.Extranjero && auxDni < 90000000)
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            else
            {
                throw new DniInvalidoException();
            }
            return auxDni;
        }

        /// <summary>
        /// Hace publicos los datos de la clas
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n" ,this.nombre,this.apellido);
            //sb.AppendLine("DNI: " + DNI);
            sb.AppendLine("Nacionalidad: " + Nacionalidad);

            return sb.ToString();
        }
        /// <summary>
        /// Enumerado con las nacionalidades posibles
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
