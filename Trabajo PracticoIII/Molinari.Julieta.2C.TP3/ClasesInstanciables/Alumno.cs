using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario 
    {
        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        public Alumno() :base()
        {

        }
        public Alumno(int id, string nombre,string apellido,string dni,ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        protected override string MostrarDatos()
        {
            string auxEstado;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                auxEstado = "Cuota al día";
            }
            else
                auxEstado = this.estadoCuenta.ToString();           
            sb.AppendLine("ESTADO DE CUENTA: " + auxEstado);
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TOMA LA CLASE DE " + this.claseQueToma);            
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool resultado = false;
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool resultado = false;
            if (a.claseQueToma != clase)
            {
                resultado = true;
            }
            return resultado;
        }


    }
}
