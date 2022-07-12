using Sistema.Entidades;
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
        public DataTable ListarMotivos()
        {
            SqlDataReader resultado; //Es una forma de leer una secuencia de filas de una DB en SQL Server.
            DataTable tabla = new DataTable(); //La clase DataTable representa una tabla en memoria.
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("categoria_listar", sqlConnection);  //Esta clase representa una instruccion
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
        public DataTable ListarIncidentes()
        {
            SqlDataReader resultado; //Es una forma de leer una secuencia de filas de una DB en SQL Server.
            DataTable tabla = new DataTable(); //La clase DataTable representa una tabla en memoria.
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("incidente_listar", sqlConnection);  //Esta clase representa una instruccion
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
        public DataTable ListarIncidentesCategorias(int valor)
        {
            SqlDataReader resultado; //Es una forma de leer una secuencia de filas de una DB en SQL Server.
            DataTable tabla = new DataTable(); //La clase DataTable representa una tabla en memoria.
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();//Raro video 13 min 6:56.
                SqlCommand comando = new SqlCommand("categoria_incidente", sqlConnection);  //Esta clase representa una instruccion
                comando.CommandType = CommandType.StoredProcedure; //Le decimos que estamos enviando un procedimiento almacenado en la DB.
                comando.Parameters.Add("@valor", SqlDbType.Int).Value = valor; //Mandamos el valor que esta en buscar para buscar los registros que coincidan con ese valor.
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
        public string Insertar(Reclamo Obj)
        {
            string respuesta = "";
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("reclamo_insertar", sqlConnection);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = Obj.idUsuario;
                comando.Parameters.Add("@idIncidente", SqlDbType.Int).Value = Obj.idIncidente;
                comando.Parameters.Add("@idMotivo", SqlDbType.Int).Value = Obj.idMotivo;
                comando.Parameters.Add("@idCalle", SqlDbType.Int).Value = Obj.idCalle;
                comando.Parameters.Add("@altura", SqlDbType.VarChar).Value = Obj.Altura;
                comando.Parameters.Add("@estado", SqlDbType.VarChar).Value = Obj.Estado;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                comando.Parameters.Add("@foto", SqlDbType.VarChar).Value = Obj.Foto;
                comando.Parameters.Add("@fecha", SqlDbType.VarChar).Value = Obj.Fecha;
                sqlConnection.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro"; //En esta variable respuesta, vamos a ingresar dos poibles valores. Si el comando se inserta de manera correcta, va a devolver un 1, por ende un OK si no se ejecuta de manera correcta dice lo otro.

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
            return respuesta; //Cualquier valor que tome este respuesta se va a mostrar en el formulario.
        }
    }
}
