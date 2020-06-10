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

        public Persona()
        {
            this.apellido = "";
            this.nombre = "";
            this.dni = 0;
        }

        public Persona(string nombre,string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            :this (nombre,apellido,nacionalidad)
        {
            this.dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this (nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }



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

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value;}
        }
                
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        private bool ValidarNombreApellido(string dato)
        {
            bool resultado = false;
            if (dato.All(char.IsLetter))
            {
                resultado = true;
            }
            return resultado;
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Valida el Dni enviado como entero
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Dni enviado de la persona</param>
        /// <returns>Dni validado según nacionalidad</returns>
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


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n" ,this.nombre,this.apellido);
            //sb.AppendLine("DNI: " + DNI);
            sb.AppendLine("Nacionalidad: " + Nacionalidad);

            return sb.ToString();
        }
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
