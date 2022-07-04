using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class DReclamo
    {
        public DataTable Listar()
        {
            SqlDataReader resultado; //Es una forma de leer una secuencia de filas de una DB en SQL Server.
            DataTable tabla = new DataTable(); //La clase DataTable representa una tabla en memoria.
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("reclamo_listar", sqlConnection);  //Esta clase representa una instruccion
                comando.CommandType = CommandType.StoredProcedure; //Le decimos que estamos enviando un procedimiento almacenado en la DB.
                sqlConnection.Open();
                resultado = comando.ExecuteReader(); //Guardamos el resultado del comando que mandamos con el execute en resultado.
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close(); //Vemos si la base esta abierta y si es asi, la cerramos.
            }
        }
    }
}
