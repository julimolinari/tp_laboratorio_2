using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Threading;

namespace MiFormulario
{
    public partial class FrmPpal : Form
    {
        Correo correo = new Correo();

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Agrega un paquete al correo al presionar el boton Agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrakingID.Text);
            paquete.InformaEstado += paq_InformaEstado;

            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {

                MessageBox.Show(ex.Message);
            }

            ActualizarEstado();


        }

        /// <summary>
        /// Llama al metodo ActualizarEstado en el hilo principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);

                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstado();
            }
        }

        /// <summary>
        /// Actualiza el estado de los paquetes mostrandolos en el listBox correspondiente
        /// </summary>
        private void ActualizarEstado()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                switch (item.Estado)
                {

                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(item);
                        break;

                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(item);
                        break;

                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(item);
                        break;

                }
            }
        }

        /// <summary>
        /// Muestra los datos de los paquetes y crea un archivo de texto con ellos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
            }
            try
            {
                elemento.MostrarDatos(elemento).Guardar("salida.txt");
                
               
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo generar el archivo.");
            }

        }

        /// <summary>
        /// Muestra los datos de los paquetes al presionar Mostrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Click derecho -> mostrar sobre el paquete entregado nos muestra sus datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Al cerrar el formulario, detiene la ejecucion de todos los hilos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }




    }
}
