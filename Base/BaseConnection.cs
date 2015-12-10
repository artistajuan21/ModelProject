using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public abstract class BaseConnection
    {
        protected SqlConnection connection;

        protected BaseConnection(){}

        public BaseConnection(SqlConnection connection)
        {
            this.connection = connection;
        }

        public SqlConnection getConnection()
        {
            return connection;
        }

        public void setConnection(SqlConnection connection)
        {
            this.connection = connection;
        }


    }
}
