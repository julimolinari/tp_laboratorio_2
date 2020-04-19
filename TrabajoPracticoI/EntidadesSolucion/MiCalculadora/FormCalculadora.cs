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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        Numero resultado = new Numero();
        /// <summary>
        /// Inicializa el formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierre el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {                            
            Close();
        }

        /// <summary>
        /// Limpia los campos del formulario
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.SelectedIndex = 0;
        }

        /// <summary>
        /// LLama a la función Limpiar().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Llama a Operar() de calculadora.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        static double Operar(string numero1, string numero2, string operador)
        {
            Numero auxNum1 = new Numero();
            Numero auxNum2 = new Numero();
            auxNum1.SetNumero = numero1;
            auxNum2.SetNumero = numero2;

            double resultado = Calculadora.Operar(auxNum1, auxNum2, operador);

            return resultado;
        }

        /// <summary>
        /// Llama a la función Operar() y muestra el resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double auxResultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            lblResultado.Text = auxResultado.ToString(); 
        }

        /// <summary>
        /// Carga el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");            
            cmbOperador.SelectedIndex = 0;
                       
        }

        /// <summary>
        /// Llama a la función para convertir el lblResultado a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {           
            string aux =lblResultado.Text;
            
            lblResultado.Text = resultado.DecimalBinario(aux);
        }

        /// <summary>
        /// Llama a la función para convertir el lblResultado a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {            
            string aux = lblResultado.Text;

            lblResultado.Text = resultado.BinarioDecimal(aux);
        }
    }
}
