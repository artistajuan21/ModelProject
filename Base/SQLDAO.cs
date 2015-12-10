using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class SQLDAO : BaseConnection
    {
        private SqlTransaction transaccion;

        public SQLDAO(SqlConnection connection)
        {
            base.setConnection(connection);
        }


        public void BeginTransaccion()
        {
            transaccion = connection.BeginTransaction();
        }

        public void CommitTransaccion()
        {
            transaccion.Commit();
        }

        public void RollBackTransaccion()
        {
            transaccion.Rollback();
        }

        public SqlCommand obtenerComandoSQL()
        {
            SqlCommand comando = connection.CreateCommand();            
            if (transaccion != null)
                comando.Transaction = transaccion;
            return comando;
        }

        public void openConnection()
        {
            connection = ConnectionStrings.conectar();
            connection.Open();
        }

        public void closeConnection()
        {
            connection.Close();
        }
    }
}
