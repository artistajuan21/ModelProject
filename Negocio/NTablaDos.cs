using System;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using AccesoDatos;
using System.Data.SqlClient;
using Base;
using System.Configuration;
namespace Negocio
{
    public class NTablaDos
    {
        private static NTablaDos _instancia;
        public static NTablaDos Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NTablaDos();
                return _instancia;
            }
        }
        protected NTablaDos() { }
        public bool insert(TablaDos obj)
        {
            SqlConnection connection = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                sqlDAO.BeginTransaccion();
                obj.fechaCreacion = System.DateTime.Now;
                obj.esActivo = true;
                obj.condicion = 1;
                DTablaDos.Instancia(sqlDAO).insert(obj);
                sqlDAO.CommitTransaccion();
            }
            catch (Exception ex)
            {
                try
                {
                    if (sqlDAO != null)
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
                if (sqlDAO != null)
                    sqlDAO.closeConnection();
            }
            return true;
        }
        public bool edit(TablaDos obj)
        {
            SqlConnection connection = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                sqlDAO.BeginTransaccion();
                TablaDos objBase = DTablaDos.Instancia(sqlDAO).Select(obj.id);
                objBase.nombre = obj.nombre;
                objBase.condicion = obj.condicion;
                DTablaDos.Instancia(sqlDAO).insert(objBase);
                sqlDAO.CommitTransaccion();
            }
            catch (Exception ex)
            {
                try
                {
                    if (sqlDAO != null)
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
                if (sqlDAO != null)
                    sqlDAO.closeConnection();
            }
            return true;
        }
        public List<TablaDos> SelectAll()
        {
            SqlConnection connection = null;
            List<TablaDos> lista = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                lista = DTablaDos.Instancia(sqlDAO).SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                if (sqlDAO != null)
                    sqlDAO.closeConnection();
            }
            return lista;
        }
        public List<TablaDos> SelectAll(bool esActivo)
        {
            SqlConnection connection = null;
            List<TablaDos> lista = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                lista = DTablaDos.Instancia(sqlDAO).SelectAll(esActivo);
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                if (sqlDAO != null)
                    sqlDAO.closeConnection();
            }
            return lista;
        }
        public TablaDos Select(Int32 id)
        {
            SqlConnection connection = null;
            TablaDos obj = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                obj = DTablaDos.Instancia(sqlDAO).Select(id);
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                if (sqlDAO != null)
                    sqlDAO.closeConnection();
            }
            return obj;
        }
        public TablaDos Select(Int32 id, bool esActivo)
        {
            SqlConnection connection = null;
            TablaDos obj = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                obj = DTablaDos.Instancia(sqlDAO).Select(id, esActivo);
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                if (sqlDAO != null)
                    sqlDAO.closeConnection();
            }
            return obj;
        }
        public bool changeCondicion(Int32 id, int condicion)
        {
            SqlConnection connection = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                DTablaDos.Instancia(sqlDAO).changeCondicion(id, condicion);
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                if (sqlDAO != null)
                    sqlDAO.closeConnection();
            }
            return true;
        }
        public bool disable(Int32 id)
        {
            SqlConnection connection = null;
            SQLDAO sqlDAO = null;
            try
            {
                sqlDAO = new SQLDAO(connection);
                sqlDAO.openConnection();
                DTablaDos.Instancia(sqlDAO).disable(id);
            }
            catch (Exception ex)
            {
                throw new Exception(Excepciones.getException(ex));
            }
            finally
            {
                if (sqlDAO != null)
                    sqlDAO.closeConnection();
            }
            return true;
        }
    }
}