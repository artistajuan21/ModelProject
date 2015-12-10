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
                return Json(NTablaUno.Instancia.SelectAll(esActivo), JsonRequestBehavior.DenyGet);
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

     
    }
}
