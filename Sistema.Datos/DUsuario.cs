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
    public class DUsuario
    {
        public DataTable Listar()
        {
            SqlDataReader resultado; //Es una forma de leer una secuencia de filas de una DB en SQL Server.
            DataTable tabla = new DataTable(); //La clase DataTable representa una tabla en memoria.
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();//Raro video 13 min 6:56.
                SqlCommand comando = new SqlCommand("usuario_listar", sqlConnection);  //Esta clase representa una instruccion
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
        public DataTable Login(string email, string clave)
        {
            SqlDataReader resultado; 
            DataTable tabla = new DataTable();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_login", sqlConnection); 
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;
                sqlConnection.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla; //Si el usuario existe va a retornar este valor.

            }
            catch (Exception ex)
            {
                return null; //Si el usuario no existe va a retornar este valor.
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close(); 
            }
        }
        public DataTable Buscar(string valor)
        {
            SqlDataReader resultado; //Es una forma de leer una secuencia de filas de una DB en SQL Server.
            DataTable tabla = new DataTable(); //La clase DataTable representa una tabla en memoria.
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();//Raro video 13 min 6:56.
                SqlCommand comando = new SqlCommand("usuario_buscar", sqlConnection);  //Esta clase representa una instruccion
                comando.CommandType = CommandType.StoredProcedure; //Le decimos que estamos enviando un procedimiento almacenado en la DB.
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor; //Mandamos el valor que esta en buscar para buscar los registros que coincidan con ese valor.
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
        public string Existe(string valor)
        {
            string respuesta = "";
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_existe", sqlConnection);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor; //enviamos el valor de valor a @valor de la db.
                SqlParameter parExiste = new SqlParameter(); //creamos el objeto parExiste
                parExiste.ParameterName = "@existe"; //elazamos parExiste a @existe de la db.
                parExiste.SqlDbType = SqlDbType.Int; //indicamos el tipo de dato.
                parExiste.Direction = ParameterDirection.Output; //indicamos que es un dato de salida.
                comando.Parameters.Add(parExiste); //lo agregamos al comando
                sqlConnection.Open();
                comando.ExecuteNonQuery();
                respuesta = (parExiste.Value).ToString();

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
            return respuesta;
        }
        public string Insertar(Usuario Obj)
        {
            string respuesta = "";
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_insertar", sqlConnection);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idRol", SqlDbType.Int).Value = Obj.idRol;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                comando.Parameters.Add("@calle", SqlDbType.Int).Value = Obj.idCalle;
                comando.Parameters.Add("@altura", SqlDbType.VarChar).Value = Obj.Altura;
                comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                comando.Parameters.Add("@dni", SqlDbType.VarChar).Value = Obj.Dni;
                comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Obj.Email;
                comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Obj.Clave;
                

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
            return respuesta;
        }
        public string Actualizar(Usuario Obj)
        {
            string respuesta = "";
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("usuario_actualizar", sqlConnection);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = Obj.idUsuario;
                comando.Parameters.Add("@idRol", SqlDbType.Int).Value = Obj.idRol;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                comando.Parameters.Add("@calle", SqlDbType.Int).Value = Obj.idCalle;
                comando.Parameters.Add("@altura", SqlDbType.VarChar).Value = Obj.Altura;
                comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                comando.Parameters.Add("@dni", SqlDbType.VarChar).Value = Obj.Dni;
                comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Obj.Email;
                comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Obj.Clave;
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
