//-------------------------  TablaDos  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidad;
using Base;
namespace AccesoDatos
{
    public class DTablaDos
    {
        private SQLDAO daoSQL;
        private static DTablaDos _instancia;
        public static DTablaDos Instancia(SQLDAO daoSQL)
        {
            _instancia = new DTablaDos(daoSQL);
            return _instancia;
        }
        protected DTablaDos(SQLDAO daoSQL) { this.daoSQL = daoSQL; }
        public Int32 insert(TablaDos obj)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            int id = 0;
            try
            {
                query = "insert into TablaDos (nombre,esActivo,condicion,fechaCreacion) VALUES " +
                 "(@nombre,@esActivo,@condicion,@fechaCreacion) select SCOPE_IDENTITY() as id";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandType = CommandType.Text;
                comando.CommandText = query; comando.Parameters.AddWithValue("@nombre", obj.nombre);
                comando.Parameters.AddWithValue("@esActivo", obj.esActivo);
                comando.Parameters.AddWithValue("@condicion", obj.condicion);
                comando.Parameters.AddWithValue("@fechaCreacion", obj.fechaCreacion);
                dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    obj.id = Convert.ToInt32(dr["id"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaDos-insert: \n" + ex.Message.ToString());
            }
            finally
            {
                dr.Close();
                comando.Parameters.Clear();
            }
            return id;
        }
        public bool edit(TablaDos obj)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            try
            {
                query = "update  TablaDos set nombre=@nombre,esActivo=@esActivo,condicion=@condicion,fechaCreacion=@fechaCreacion where id=@id";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id", obj.id);
                comando.Parameters.AddWithValue("@nombre", obj.nombre);
                comando.Parameters.AddWithValue("@esActivo", obj.esActivo);
                comando.Parameters.AddWithValue("@condicion", obj.condicion);
                comando.Parameters.AddWithValue("@fechaCreacion", obj.fechaCreacion);
                comando.Parameters.AddWithValue("@id", obj.id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaDos-Edit: \n" + ex.Message.ToString());
            }
            finally
            {
                comando.Parameters.Clear();
            }
            return true;
        }
        public List<TablaDos> SelectAll()
        {
            String query = string.Empty;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            List<TablaDos> lista = null;
            try
            {
                lista = new List<TablaDos>();
                query = "select id,nombre,esActivo,condicion,fechaCreacion from TablaDos";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    TablaDos obj = new TablaDos();
                    obj.id = Convert.ToInt32(dr["id"]);
                    obj.nombre = Convert.ToString(dr["nombre"]);
                    obj.esActivo = Convert.ToBoolean(dr["esActivo"]);
                    obj.condicion = Convert.ToInt16(dr["condicion"]);
                    obj.fechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]);

                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaDos-selectAll: \n" + ex.Message.ToString());
            }
            finally
            {
                dr.Close();
                comando.Parameters.Clear();
            }
            return lista;
        }
        public List<TablaDos> SelectAll(bool esActivo)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            List<TablaDos> lista = null;
            try
            {
                lista = new List<TablaDos>();
                query = "select id,nombre,esActivo,condicion,fechaCreacion from TablaDos where esActivo=@esActivo ";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@esActivo", esActivo);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    TablaDos obj = new TablaDos();
                    obj.id = Convert.ToInt32(dr["id"]);
                    obj.nombre = Convert.ToString(dr["nombre"]);
                    obj.esActivo = Convert.ToBoolean(dr["esActivo"]);
                    obj.condicion = Convert.ToInt16(dr["condicion"]);
                    obj.fechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]);

                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaDos-selectAll: \n" + ex.Message.ToString());
            }
            finally
            {
                dr.Close();
                comando.Parameters.Clear();
            }
            return lista;
        }
        public TablaDos Select(Int32 id)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            TablaDos obj = null;
            try
            {
                query = "select id,nombre,esActivo,condicion,fechaCreacion from TablaDos where id=@id ";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id", id);
                dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    obj = new TablaDos();
                    obj.id = Convert.ToInt32(dr["id"].ToString());
                    obj.nombre = Convert.ToString(dr["nombre"].ToString());
                    obj.esActivo = Convert.ToBoolean(dr["esActivo"].ToString());
                    obj.condicion = Convert.ToInt16(dr["condicion"].ToString());
                    obj.fechaCreacion = Convert.ToDateTime(dr["fechaCreacion"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaDos-select: \n" + ex.Message.ToString());
            }
            finally
            {
                dr.Close();
                comando.Parameters.Clear();
            }
            return obj;
        }
        public TablaDos Select(Int32 id, bool esActivo)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            TablaDos obj = null;
            try
            {
                query = "select id,nombre,esActivo,condicion,fechaCreacion from TablaDos where id=@id and esActivo=@esActivo ";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@esActivo", esActivo);
                dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    obj = new TablaDos();
                    obj.id = Convert.ToInt32(dr["id"].ToString());
                    obj.nombre = Convert.ToString(dr["nombre"].ToString());
                    obj.esActivo = Convert.ToBoolean(dr["esActivo"].ToString());
                    obj.condicion = Convert.ToInt16(dr["condicion"].ToString());
                    obj.fechaCreacion = Convert.ToDateTime(dr["fechaCreacion"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaDos-select: \n" + ex.Message.ToString());
            }
            finally
            {
                dr.Close();
                comando.Parameters.Clear();
            }
            return obj;
        }
        public bool changeCondicion(Int32 id, int condicion)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            try
            {
                query = "update  TablaDos set condicion=@condicion where id=@id";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@condicion", condicion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaDos-changeCondicion: \n" + ex.Message.ToString());
            }
            finally
            {
                comando.Parameters.Clear();
            }
            return true;
        }
        public bool disable(Int32 id)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            try
            {
                query = "update  TablaDos set esActivo=false where id=@id";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaDos-disable: \n" + ex.Message.ToString());
            }
            finally
            {
                comando.Parameters.Clear();
            }
            return true;
        }
    }
}