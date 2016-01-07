//------------------------------------------------------------------------------
// Author: Julio Becerra Urbina 
// Fecha: 2015_diciembre_02 - 11_08_12 
//-------------------------  TablaUno  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidad;
using Negocio;
using Utilidades;

namespace Vista.Controllers
{
    public class TablaUnoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult save(TablaUno objJson)
        {
            try
            {
                if (objJson.id == 0)
                {
                    NTablaUno.Instancia.insert(objJson);
                }
                else
                {
                    NTablaUno.Instancia.edit(objJson);
                }
                return Json("ok", JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.DenyGet);
            }
        }
        [HttpPost]
        public JsonResult selectAllbyActivo(bool esActivo)
        {
            try
            {
                List<TablaUno> lista=NTablaUno.Instancia.SelectAll(esActivo);
                return Json(lista, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult selectAll()
        {
            try
            {
                return Json(NTablaUno.Instancia.SelectAll(), JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.DenyGet);
            }
        }
        [HttpPost]
        public JsonResult select(int id, bool esActivo)
        {
            try
            {
                TablaUno obj = NTablaUno.Instancia.Select(id, esActivo);
                if (obj == null)
                {
                    return Json("empty", JsonRequestBehavior.DenyGet);
                }
                return Json(obj, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.DenyGet);
            }
        }
        [HttpPost]
        public JsonResult changeCondicion(int id, int condicion)
        {
            try
            {
                NTablaUno.Instancia.changeCondicion(id, condicion);
                return Json("ok", JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.DenyGet);
            }
        }
       
        [HttpPost]
        public JsonResult disable(int id)
        {
            try
            {
                NTablaUno.Instancia.disable(id);
                return Json("ok", JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.DenyGet);
            }
        }

        public JsonResult SelectAllForDataTable(int draw, int start, int length, Dictionary<string, string> search, Dictionary<string, Dictionary<string, string>> order)
        {
            #region Parametros del DataTable
            Dictionary<string, string> orderArray = order["0"];

            int column = Convert.ToInt32(orderArray["column"]);
            string ordenAscDesc = orderArray["dir"];

            string valSearch = search["value"];
            #endregion
            
            List<TablaUno> lista = NTablaUno.Instancia.SelectAllForDataTable(start, length, valSearch, column, ordenAscDesc);

            JsonFormatDataTable jsonReturn = new JsonFormatDataTable();

            jsonReturn.draw = draw;
            jsonReturn.recordsTotal = 0;
            jsonReturn.recordsFiltered = 0;

            if (lista != null && lista.Count() > 0)
            {
                jsonReturn.recordsTotal = lista.ElementAt(0).recordsTotal;
                jsonReturn.recordsFiltered = lista.ElementAt(0).recordsFiltered;
            }

            foreach (var item in lista)
            {

                string[] cadena = new string[8];

                cadena[0] = item.id.ToString();
                cadena[1] = item.unico;
                cadena[2] = item.fechaCreacion.ToShortDateString();
                cadena[3] = item.fecha.ToString();
                cadena[4] = item.condicion.ToString();
                cadena[5] = item.hora.ToString();
                cadena[6] = item.numero.ToString();
                cadena[7] = item.TablaDos.nombre;


                jsonReturn.data.Add(cadena);
            }

            return Json(jsonReturn, JsonRequestBehavior.AllowGet); 
        }
     
    }
}
