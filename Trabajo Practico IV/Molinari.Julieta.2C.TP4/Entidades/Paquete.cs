using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        string direccionEntrega;
        EEstado estado;
        string trackingID;

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Constructor de paquete con parametros
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        

        /// <summary>
        /// Propiedad de direccion de entrega
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        /// <summary>
        /// Propiedad de estados
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /// <summary>
        /// Propiedad de tracking ID
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }


        /// <summary>
        /// Simula el ciclo de vida de un paquete cambiandolo de estado cada 4 segundos
        /// </summary>
        public void MockCicloDeVida()
        {
            int estadoLen = Enum.GetNames(typeof(EEstado)).Length;
            int contador = 1;
            try
            {
                do
                {
                    Thread.Sleep(4000);
                    this.estado = (EEstado)contador;
                    if (this.InformaEstado != null)
                    {
                        this.InformaEstado(this, new EventArgs());
                    }
                    contador++;
                } while (contador < estadoLen);
                if (this.estado == EEstado.Entregado)
                {
                    PaqueteDAO.Insertar(this);
                }
            }
            
            catch (Exception)
            {
                Thread.ResetAbort();
            }
        }


        /// <summary>
        /// Muestra los datos de un paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)(elemento);
            return string.Format("{0} para {1}", p.TrackingID, p.DireccionEntrega);
        }

        /// <summary>
        /// Compara si dos paquetes son iguales por su tracking ID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1,Paquete p2)
        {
            bool resultado = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                resultado = true;
            }
            return resultado;
        }

        /// <summary>
        /// Compara si dos paquetes son distintos por su tracking ID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Retorna la informacion del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MostrarDatos(this));           

            return sb.ToString();
        }

        /// <summary>
        /// Enumerado con los estados posibles de un paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
    }
}
