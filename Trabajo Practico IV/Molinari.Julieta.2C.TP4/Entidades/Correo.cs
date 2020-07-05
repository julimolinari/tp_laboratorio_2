using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        /// <summary>
        /// Propiedad de paquete
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        /// <summary>
        /// Constructor por defecto de Correo
        /// </summary>
        public Correo()
        {
            this.Paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        /// <summary>
        /// Metodo que detiene todos los hilos en ejecucion
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }
            }
        }

        /// <summary>
        /// Metodo que muestra los datos de todo slos paquetes de la lista
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> paquetesAux = ((Correo)elementos).paquetes;
            StringBuilder resultado = new StringBuilder();
            foreach (Paquete item in paquetesAux)
            {
                resultado.AppendLine(string.Format("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado));
            }
            return resultado.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar paquetes al correo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            if (c.paquetes != null)
            {
                foreach (Paquete item in c.Paquetes)
                {
                    if (item == p)
                    {
                        throw new TrackingIdRepetidoException("El paquete ya esta en la lista.");
                    }
                }

                c.paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hilo);
                hilo.Start();

            }

            return c;
        }

    }
}
