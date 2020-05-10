using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor por defecto de la clase Numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            double aux;
            double.TryParse(strNumero, out aux)
            this.numero = aux;
        }
        /// <summary>
        /// Función para validar que el valor ingresado sea númerico, si no devuelve 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double resultado = 0;
            double aux;        
            if (double.TryParse(strNumero, out aux)) 
            {
                resultado = aux;
            }
            return resultado;
        }

       /// <summary>
       /// Propiedad: asigna un valor al atributo numero.
       /// </summary>
        public string SetNumero
        {
            set
            {
                double resultado = ValidarNumero(value);
                this.numero = resultado;
            }
        }

        /// <summary>
        /// Válida el número y en caso de poder lo convierte a deciimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            char[] arrayNumerico = binario.ToCharArray();
            
            Array.Reverse(arrayNumerico);
            
            int resultado= 0;

            for (int i = 0; i < arrayNumerico.Length; i++)
            {
                if (arrayNumerico[i] == '1')
                {
                    if (i == 0)
                    {
                        resultado += 1;
                    }
                    else
                    {
                        resultado += (int)Math.Pow(2, i);
                    }
                }else if(arrayNumerico[i] != '0')
                {
                    return "Valor inválido";
                }
            }
            return resultado.ToString();
        }

        /// <summary>
        /// Válida el número y en caso de poder lo convierte a binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string resultado ="";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        resultado = "0" + resultado;
                    }
                    else
                    {
                        resultado = "1" + resultado;
                    }
                    numero = (int)(numero / 2);
                }                
            } else
            {
                if (numero == 0)
                {
                    resultado = "0";
                }
                else
                {
                    resultado = "Valor inválido";
                }
            }
            return resultado;
        }
        /// <summary>
        /// Intenta convertir el string a double, lo válida  y en caso de poder lo convierte a binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            string resultado;
            double aux;
            if(double.TryParse(numero, out aux))
            {
                resultado = DecimalBinario(aux);
            }else
            {
                resultado = "Valor inválido";
            }          
            
            return resultado;
        }

        /// <summary>
        /// Sobre carga de - para operar con Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator -(Numero num1, Numero num2)
        {
            double resultado = 0;            
            if (num1 != null && num2 != null)
            {
                double auxNum1 = num1.numero;
                double auxNum2 = num2.numero;
                resultado = auxNum1 - auxNum2;
            }
            return resultado;
        }
        /// <summary>
        /// Sobre carga de + para operar con Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator +(Numero num1, Numero num2)
        {
            double resultado = 0;
            if (num1 != null && num2 != null)
            {
                double auxNum1 = num1.numero;
                double auxNum2 = num2.numero;
                resultado = auxNum1 + auxNum2;
            }
            return resultado;
        }
        /// <summary>
        /// Sobre carga de / para operar con Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator /(Numero num1, Numero num2)
        {
            double resultado = 0;
            if (num1 != null && num2 != null)
            {
                double auxNum1 = num1.numero;
                double auxNum2 = num2.numero;
                if (auxNum2 == 0)
                {
                    resultado = double.MinValue;
                }else
                    resultado = auxNum1 / auxNum2;
            }
            return resultado;
        }
        /// <summary>
        /// Sobre carga de * para operar con Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator *(Numero num1, Numero num2)
        {
            double resultado = 0;
            if (num1 != null && num2 != null)
            {
                double auxNum1 = num1.numero;
                double auxNum2 = num2.numero;
                resultado = auxNum1 * auxNum2;
            }
            return resultado;
        }
    }
}
