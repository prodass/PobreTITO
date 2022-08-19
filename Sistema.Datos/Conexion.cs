using System;
using System.Data.SqlClient;

namespace Sistema.Datos
{
    public class Conexion
    {
        private static Conexion Con = null;
        
        private Conexion()
        {
            
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server = minubepablo.ddns.net,1433; Database = PobreTITO; User Id = sa; Password = 1234Pablo"; //REMOTO
                //Cadena.ConnectionString = "Data Source=INSPIRON3583\\PABLOSQL;Initial Catalog=PobreTITO;Integrated Security=True";
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }
        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
