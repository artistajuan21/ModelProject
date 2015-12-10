//-------------------------  TablaUno  ----------------------------------------
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
    public class DTablaUno
    {
        private SQLDAO daoSQL;
        private static DTablaUno _instancia;
        public static DTablaUno Instancia(SQLDAO daoSQL)
        {
            _instancia = new DTablaUno(daoSQL);
            return _instancia;
        }
        protected DTablaUno(SQLDAO daoSQL) { this.daoSQL = daoSQL; }
        public Int64 insert(TablaUno obj)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            int id = 0;
            try
            {
                query = "insert into TablaUno (nombre,unico,fechaCreacion,fecha,condicion,hora,numero,idTablaDos,esActivo) VALUES " +
                 "(@nombre,@unico,@fechaCreacion,@fecha,@condicion,@hora,@numero,@idTablaDos,@esActivo) select SCOPE_IDENTITY() as id";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandType = CommandType.Text;
                comando.CommandText = query; comando.Parameters.AddWithValue("@nombre", obj.nombre);
                comando.Parameters.AddWithValue("@unico", obj.unico);
                comando.Parameters.AddWithValue("@fechaCreacion", obj.fechaCreacion);
                comando.Parameters.AddWithValue("@fecha", obj.fecha);
                comando.Parameters.AddWithValue("@condicion", obj.condicion);
                comando.Parameters.AddWithValue("@hora", obj.hora);
                comando.Parameters.AddWithValue("@numero", obj.numero);
                comando.Parameters.AddWithValue("@idTablaDos", obj.idTablaDos);
                comando.Parameters.AddWithValue("@esActivo", obj.esActivo);
                dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    obj.id = Convert.ToInt64(dr["id"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaUno-insert: \n" + ex.Message.ToString());
            }
            finally
            {
                dr.Close();
                comando.Parameters.Clear();
            }
            return id;
        }
        public bool edit(TablaUno obj)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            try
            {
                query = "update  TablaUno set nombre=@nombre,unico=@unico,fechaCreacion=@fechaCreacion,fecha=@fecha,condicion=@condicion,hora=@hora,numero=@numero,idTablaDos=@idTablaDos,esActivo=@esActivo where id=@id";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id", obj.id);
                comando.Parameters.AddWithValue("@nombre", obj.nombre);
                comando.Parameters.AddWithValue("@unico", obj.unico);
                comando.Parameters.AddWithValue("@fechaCreacion", obj.fechaCreacion);
                comando.Parameters.AddWithValue("@fecha", obj.fecha);
                comando.Parameters.AddWithValue("@condicion", obj.condicion);
                comando.Parameters.AddWithValue("@hora", obj.hora);
                comando.Parameters.AddWithValue("@numero", obj.numero);
                comando.Parameters.AddWithValue("@idTablaDos", obj.idTablaDos);
                comando.Parameters.AddWithValue("@esActivo", obj.esActivo);
                comando.Parameters.AddWithValue("@id", obj.id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaUno-Edit: \n" + ex.Message.ToString());
            }
            finally
            {
                comando.Parameters.Clear();
            }
            return true;
        }
        public List<TablaUno> SelectAll()
        {
            String query = string.Empty;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            List<TablaUno> lista = null;
            try
            {
                lista = new List<TablaUno>();
                query = "select id,nombre,unico,fechaCreacion,fecha,condicion,hora,numero,idTablaDos,esActivo from TablaUno";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    TablaUno obj = new TablaUno();
                    obj.id = Convert.ToInt64(dr["id"]);
                    obj.nombre = Convert.ToString(dr["nombre"]);
                    obj.unico = Convert.ToString(dr["unico"]);
                    obj.fechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]);
                    obj.fecha = Convert.ToDateTime(dr["fecha"]);
                    obj.condicion = Convert.ToInt16(dr["condicion"]);
                    obj.hora = TimeSpan.Parse(dr["hora"].ToString());
                    obj.numero = Convert.ToInt32(dr["numero"]);
                    obj.idTablaDos = Convert.ToInt32(dr["idTablaDos"]);
                    obj.esActivo = Convert.ToBoolean(dr["esActivo"]);

                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaUno-selectAll: \n" + ex.Message.ToString());
            }
            finally
            {
                dr.Close();
                comando.Parameters.Clear();
            }
            return lista;
        }
        public List<TablaUno> SelectAll(bool esActivo)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            List<TablaUno> lista = null;
            try
            {
                lista = new List<TablaUno>();
                query = "select id,nombre,unico,fechaCreacion,fecha,condicion,hora,numero,idTablaDos,esActivo from TablaUno where esActivo=@esActivo ";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@esActivo", esActivo);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    TablaUno obj = new TablaUno();
                    obj.id = Convert.ToInt64(dr["id"]);
                    obj.nombre = Convert.ToString(dr["nombre"]);
                    obj.unico = Convert.ToString(dr["unico"]);
                    obj.fechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]);
                    obj.fecha = Convert.ToDateTime(dr["fecha"]);
                    obj.condicion = Convert.ToInt16(dr["condicion"]);
                    obj.hora = TimeSpan.Parse(dr["hora"].ToString());
                    obj.numero = Convert.ToInt32(dr["numero"]);
                    obj.idTablaDos = Convert.ToInt32(dr["idTablaDos"]);
                    obj.esActivo = Convert.ToBoolean(dr["esActivo"]);

                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaUno-selectAll: \n" + ex.Message.ToString());
            }
            finally
            {
                dr.Close();
                comando.Parameters.Clear();
            }
            return lista;
        }
        public TablaUno Select(Int64 id)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            TablaUno obj = null;
            try
            {
                query = "select id,nombre,unico,fechaCreacion,fecha,condicion,hora,numero,idTablaDos,esActivo from TablaUno where id=@id ";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id", id);
                dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    obj = new TablaUno();
                    obj.id = Convert.ToInt64(dr["id"].ToString());
                    obj.nombre = Convert.ToString(dr["nombre"].ToString());
                    obj.unico = Convert.ToString(dr["unico"].ToString());
                    obj.fechaCreacion = Convert.ToDateTime(dr["fechaCreacion"].ToString());
                    obj.fecha = Convert.ToDateTime(dr["fecha"].ToString());
                    obj.condicion = Convert.ToInt16(dr["condicion"].ToString());
                    obj.hora = TimeSpan.Parse(dr["hora"].ToString());
                    obj.numero = Convert.ToInt32(dr["numero"].ToString());
                    obj.idTablaDos = Convert.ToInt32(dr["idTablaDos"].ToString());
                    obj.esActivo = Convert.ToBoolean(dr["esActivo"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaUno-select: \n" + ex.Message.ToString());
            }
            finally
            {
                dr.Close();
                comando.Parameters.Clear();
            }
            return obj;
        }
        public TablaUno Select(Int64 id, bool esActivo)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            TablaUno obj = null;
            try
            {
                query = "select id,nombre,unico,fechaCreacion,fecha,condicion,hora,numero,idTablaDos,esActivo from TablaUno where id=@id and esActivo=@esActivo ";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@esActivo", esActivo);
                dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    obj = new TablaUno();
                    obj.id = Convert.ToInt64(dr["id"].ToString());
                    obj.nombre = Convert.ToString(dr["nombre"].ToString());
                    obj.unico = Convert.ToString(dr["unico"].ToString());
                    obj.fechaCreacion = Convert.ToDateTime(dr["fechaCreacion"].ToString());
                    obj.fecha = Convert.ToDateTime(dr["fecha"].ToString());
                    obj.condicion = Convert.ToInt16(dr["condicion"].ToString());
                    obj.hora = TimeSpan.Parse(dr["hora"].ToString());
                    obj.numero = Convert.ToInt32(dr["numero"].ToString());
                    obj.idTablaDos = Convert.ToInt32(dr["idTablaDos"].ToString());
                    obj.esActivo = Convert.ToBoolean(dr["esActivo"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaUno-select: \n" + ex.Message.ToString());
            }
            finally
            {
                dr.Close();
                comando.Parameters.Clear();
            }
            return obj;
        }
        public bool changeCondicion(Int64 id, int condicion)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            try
            {
                query = "update  TablaUno set condicion=@condicion where id=@id";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@condicion", condicion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaUno-changeCondicion: \n" + ex.Message.ToString());
            }
            finally
            {
                comando.Parameters.Clear();
            }
            return true;
        }
        public bool disable(Int64 id)
        {
            String query = string.Empty;
            SqlCommand comando = null;
            try
            {
                query = "update  TablaUno set esActivo=0 where id=@id";
                comando = daoSQL.obtenerComandoSQL();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DTablaUno-disable: \n" + ex.Message.ToString());
            }
            finally
            {
                comando.Parameters.Clear();
            }
            return true;
        }
    }
}
