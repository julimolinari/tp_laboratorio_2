using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;

        /// <summary>
        /// Constructor po defecto, inicializa la conexion a la base y el command.
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection("Data Source = .; Database =correo-sp-2017; Trusted_Connection=True;");
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }

        /// <summary>
        /// Inserta paquetes en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
       public static bool Insertar(Paquete p)
       {
            bool resultado = false;
            try
            {
                comando.CommandText = "INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES (@direccionEntrega, @trackingID,@alumno);";
                comando.Parameters.Clear();
                
                comando.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
                comando.Parameters.AddWithValue("@trackingID", p.TrackingID);
                comando.Parameters.AddWithValue("@alumno", "Julieta Molinari");

                conexion.Open();
                comando.ExecuteNonQuery();

                resultado = true;
            }

            catch (Exception ex)
            {

                throw new TrackingIdRepetidoException("Error al ingresar un nuevo paquete.", ex);
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return resultado;
        }

        
    }
}
