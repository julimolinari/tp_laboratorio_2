﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        public Universitario()
        {

        }

        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
            :base (nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this.legajo);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();    

        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool resultado = false;
            if (pg1.Equals(pg2) && pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                resultado = true;
            }
            return resultado;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


    }
}