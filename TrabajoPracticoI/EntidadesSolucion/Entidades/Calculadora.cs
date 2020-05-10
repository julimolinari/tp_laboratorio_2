using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Funcion validar operador: se fija que los operadores ingresados sean validos
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>el operador ingresado, o "+" si no es valido lo ingresado</returns>
        private static string ValidarOperador(string operador)
        {
            string operAux = "+";
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                operAux = operador;
            }
            return operAux;              
        }

        /// <summary>
        /// Realiza las operaciones entre los numeros pasados por parametro
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado como double</returns>
        public static double Operar(Numero num1, Numero num2,string operador)
        {
            double resultado = 0;
            string operadorAux = Calculadora.ValidarOperador(operador);
            switch (operadorAux)
            {
                case "+":
                    resultado = num1 + num2;
                    break;

                case "-":
                    resultado = num1 - num2;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
    }
}
