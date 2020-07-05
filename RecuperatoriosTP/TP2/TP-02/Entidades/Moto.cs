using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {        
        
        /// <summary>
        ///Propiedad del tamaño: Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Moto.ETamanio.Chico;
            }
        }

        /// <summary>
        /// Constructor de moto
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Moto(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {
        }

        /// <summary>
        /// Metodo mostrar, imprime datos de la moto
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
