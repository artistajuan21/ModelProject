//------------------------------------------------------------------------------
// Author: Julio Becerra Urbina 
// Fecha: 2015_diciembre_02 - 11_08_12 
//-------------------------  TablaDos  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidad;
using Negocio;
namespace Vista.Controllers
{
    public class TablaDosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]
        public JsonResult save(TablaDos objJson)
        {
            try
            {
                if (objJson.id == 0)
                {
                    NTablaDos.Instancia.insert(objJson);
                }
                else
                {
                    NTablaDos.Instancia.edit(objJson);
                }
                return Json("ok", JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.DenyGet);
            }
        }
        [HttpPost]
        public JsonResult selectAll(bool esActivo)
        {
            try
            {
                return Json(NTablaDos.Instancia.SelectAll(esActivo), JsonRequestBehavior.DenyGet);
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
                TablaDos obj = NTablaDos.Instancia.Select(id, esActivo);
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
                NTablaDos.Instancia.changeCondicion(id, condicion);
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
                NTablaDos.Instancia.disable(id);
                return Json("ok", JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.DenyGet);
            }
        }
    }
}
