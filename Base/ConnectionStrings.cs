using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public static class ConnectionStrings
    {
        public static SqlConnection conectar()
        {
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection();
                conexion.ConnectionString = ConfigurationManager.AppSettings["conexionBD"];
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("CadenaConexion-conectando: \n" + ex.Message.ToString());
            }
            
        }
    }
}
