//-------------------------  TablaUno  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using AccesoDatos;
using System.Data.SqlClient;
using Base;
using System.Configuration;
using Utilidades;

namespace Negocio
{
    public class NTablaUno
    {
        private static NTablaUno _instancia;
        public static NTablaUno Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NTablaUno();
                return _instancia;
            }
        }
        protected NTablaUno() { }
        public bool insert(TablaUno obj)
        {
            SqlConnection connection = null;
            SQLDAO sqlDAO = null;
            try
            {                               
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                sqlDAO.BeginTransaccion();
                obj.fecha = Utilidades.ZonaHoraria.convertFecha(obj.fecha);
                obj.fechaCreacion = Utilidades.ZonaHoraria.getFechaHora();
                obj.esActivo = true;
                obj.condicion = 1;
                DTablaUno.Instancia(sqlDAO).insert(obj);
                sqlDAO.CommitTransaccion();
            }
            catch (Exception ex)
            {
                try
                {
                     sqlDAO.RollBackTransaccion();
                }
                catch (Exception )
                {                    
                    
                }finally{                    
                    throw new Exception(Excepciones.getException(ex));  
                }                
                              
            }
            finally
            {
                    sqlDAO.closeConnection();
            }
            return true;
        }
        public bool edit(TablaUno obj)
        {
            SqlConnection connection = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                sqlDAO.BeginTransaccion();
                TablaUno objBase = DTablaUno.Instancia(sqlDAO).Select(obj.id);
                objBase.nombre = obj.nombre;
                objBase.unico = obj.unico;
                objBase.fecha = obj.fecha;
                objBase.condicion = obj.condicion;
                objBase.hora = obj.hora;
                objBase.numero = obj.numero;
                objBase.idTablaDos = obj.idTablaDos;
                DTablaUno.Instancia(sqlDAO).insert(objBase);
                sqlDAO.CommitTransaccion();
            }
            catch (Exception ex)
            {
                try
                {
                        sqlDAO.RollBackTransaccion();
                }
                catch (Exception)
                {

                }
                finally
                {
                    throw new Exception(Excepciones.getException(ex));
                } 
            }
            finally
            {
                    sqlDAO.closeConnection();
            }
            return true;
        }
        public List<TablaUno> SelectAll()
        {
            SqlConnection connection = null;
            List<TablaUno> lista = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                lista = DTablaUno.Instancia(sqlDAO).SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                    sqlDAO.closeConnection();
            }
            return lista;
        }
        public List<TablaUno> SelectAll(bool esActivo)
        {
            SqlConnection connection = null;
            List<TablaUno> lista = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                lista = DTablaUno.Instancia(sqlDAO).SelectAll(esActivo);
                 TablaDos obj=null;
                for (int i = 0; i < lista.Count; i++)
                {
                   obj=new TablaDos();
                    obj=DTablaDos.Instancia(sqlDAO).Select(lista.ElementAt(i).idTablaDos);
                    lista.ElementAt(i).TablaDos = obj;
                }
            }
            catch (Exception ex)
            {
              throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                    sqlDAO.closeConnection();
            }
            return lista;
        }
        public TablaUno Select(Int64 id)
        {
            SqlConnection connection = null;
            TablaUno obj = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                obj = DTablaUno.Instancia(sqlDAO).Select(id);
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                    sqlDAO.closeConnection();
            }
            return obj;
        }
        public TablaUno Select(Int64 id, bool esActivo)
        {
            SqlConnection connection = null;
            TablaUno obj = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                obj = DTablaUno.Instancia(sqlDAO).Select(id, esActivo);
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                    sqlDAO.closeConnection();
            }
            return obj;
        }
        public bool changeCondicion(Int64 id, int condicion)
        {
            SqlConnection connection = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                DTablaUno.Instancia(sqlDAO).changeCondicion(id, condicion);
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                    sqlDAO.closeConnection();
            }
            return true;
        }
        public bool disable(Int64 id)
        {
            SqlConnection connection = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                DTablaUno.Instancia(sqlDAO).disable(id);
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                    sqlDAO.closeConnection();
            }
            return true;
        }


        public List<TablaUno> SelectAllForDataTable(int start,int length,string searchValue,int column,string ordenAscDesc)
        {
            SqlConnection connection = null;
            List<TablaUno> lista = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();

                string orderByClause = " Order By ";

                if (!string.IsNullOrEmpty(ordenAscDesc))
                {
                    string columna = column.ToString();
                    columna = columna.Replace("0", ", nombre");
                    columna = columna.Replace("1", ", unico");
                    columna = columna.Replace("2", ", fechaCreacion");
                    columna = columna.Replace("3", ", fecha");
                    columna = columna.Replace("4", ", condicion");
                    columna = columna.Replace("5", ", hora");
                    columna = columna.Replace("6", ", numero");
                    columna = columna.Replace("7", ", idTablaDos");
                    columna = columna.Replace("8", ", esActivo");
                    columna = columna.Remove(0, 1);

                    orderByClause += (ordenAscDesc.Equals("asc") ? columna : columna + " desc ");
                }

                string whereClause = string.Empty;

                if (!string.IsNullOrEmpty(searchValue))
                {
                    whereClause = " where nombre like '";
                    whereClause += searchValue;
                    whereClause += "%' or unico like '";
                    whereClause += searchValue;
                    whereClause += "%' or fechaCreacion like '";
                    whereClause += searchValue;
                    whereClause += "%' or fecha like '";
                    whereClause += searchValue;
                    whereClause += "%' or condicion like '";
                    whereClause += searchValue;
                    whereClause += "%' or hora like '";
                    whereClause += searchValue;
                    whereClause += "%' or numero like '";
                    whereClause += searchValue;
                    whereClause += "%' or idTablaDos like '";
                    whereClause += searchValue;
                    whereClause += "%' or esActivo like '";
                    whereClause += searchValue;
                    whereClause += "%' ";
                }    

                lista = DTablaUno.Instancia(sqlDAO).SelectAllForDataTable(start+1,start+length,searchValue,orderByClause,whereClause);

                TablaDos obj = null;
                for (int i = 0; i < lista.Count; i++)
                {
                    obj = new TablaDos();
                    obj = DTablaDos.Instancia(sqlDAO).Select(lista.ElementAt(i).idTablaDos);
                    lista.ElementAt(i).TablaDos = obj;
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                sqlDAO.closeConnection();
            }
            return lista;
        }

        
    }
}
