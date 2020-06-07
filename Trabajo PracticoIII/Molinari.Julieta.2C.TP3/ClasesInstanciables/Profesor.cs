using System;
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

        public Profesor() : base()
        {
           
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido,string dni,ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        private void  _randomClases()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            clasesDelDia.Enqueue((Universidad.EClases)(random.Next(0, 3)));
            clasesDelDia.Enqueue((Universidad.EClases)(random.Next(0, 3)));
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());            

            return sb.ToString();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool resultado = false;
            if (i.clasesDelDia.Contains(clase))
            {
                resultado = true;
            }
            return resultado;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

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
