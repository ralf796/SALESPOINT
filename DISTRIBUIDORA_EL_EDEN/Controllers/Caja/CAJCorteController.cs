using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ventas.Class;
using BE;
using BLL;
using DISTRIBUIDORA_EL_EDEN;

namespace Ventas.Controllers.Caja
{
    public class CAJCorteController : Controller
    {
        // GET: CAJCorte
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        //-------------------funcion getcorte--------------------
        [SessionExpireFilter]
        public JsonResult GetCorte()
        {
            try
            {
                var item = new Caja_BE();
                item.MTIPO = 4;
                var lista = Connect.Connect_Caja(item);

                foreach (var row in lista)
                    row.FECHA_CREACION_STRING = row.FECHA_CREACION.ToString("dd/MM/yyyy");

                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        /*funcion que aplica corte*/
        [SessionExpireFilter]
        public JsonResult GetAplicarCorte()
        {
            try
            {
                var item = new Caja_BE();
                item.CREADO_POR= Session["usuario"].ToString();
                item.MTIPO = 6;
                var lista = Connect.Connect_Caja(item);
                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        /*---------------funcion Total Venta----------------------*/
        [SessionExpireFilter]
        public JsonResult TotalVentaCorte()
        {
            try
            {
                var item = new Caja_BE();
                item.MTIPO = 7;
                var lista = Connect.Connect_Caja(item);
                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public JsonResult GetTotalTarjeta()
        {
            try
            {
                var item = new Caja_BE();
                item.MTIPO = 8;
                var lista = Connect.Connect_Caja(item);
                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public JsonResult GetTotalEfectivo()
        {
            try
            {
                var item = new Caja_BE();
                item.MTIPO = 9;
                var lista = Connect.Connect_Caja(item);
                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}