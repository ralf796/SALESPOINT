using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ventas.Class;
using BE;
using BLL;
using DISTRIBUIDORA_EL_EDEN;

namespace Ventas.Controllers.Cartera
{
    public class CARSaldosController : Controller
    {
        // GET: CARSaldos
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEstadoCuentaCliente(int ID_CLIENTE = 0)
        {
            try
            {
                var item = new Cartera_BE();
                List<Cartera_BE> lista = new List<Cartera_BE>();
                item.ID_CLIENTE = ID_CLIENTE;
                item.MTIPO = 5;
                lista = Connect.Connect_Cartera(item);

                foreach(var row in lista)
                {
                    row.FECHA_CREACION_CREDITO_STRING = row.FECHA_CREACION_CREDITO.ToString("dd/MM/yyyy hh:mm tt");
                    row.FECHA_VENTA_STRING = row.FECHA_VENTA.ToString("dd/MM/yyyy hh:mm tt");
                    row.FECHA_PAGO_STRING = Convert.ToDateTime(row.FECHA_PAGO).ToString("dd/MM/yyyy hh:mm tt");
                }

                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetClientes()
        {
            try
            {
                var item = new Cartera_BE();
                List<Cartera_BE> lista = new List<Cartera_BE>();
                item.MTIPO = 7;
                lista = Connect.Connect_Cartera(item);
                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}