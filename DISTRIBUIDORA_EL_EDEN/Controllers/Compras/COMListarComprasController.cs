using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE;
using BLL;
using DISTRIBUIDORA_EL_EDEN;

namespace Ventas.Controllers.Compras
{
    public class COMListarComprasController : Controller
    {
        // GET: COMListarCompras
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDatos(string fechaInicial = "", string fechaFinal = "")
        {
            try
            {
                var item = new Inventario_BE();
                item.MTIPO = 2;
                item.FECHA_ENTREGA = DateTime.Now;
                item.FECHA_PEDIDO = DateTime.Now;
                item.FECHA_PAGO = DateTime.Now;
                var lista = Connect.Connect_Compras(item);
                foreach (var row in lista)
                {
                    row.FECHA_ENTREGA_STRING = row.FECHA_ENTREGA.ToString("dd/MM/yyyy");
                    row.FECHA_PEDIDO_STRING = row.FECHA_PEDIDO.ToString("dd/MM/yyyy");
                    row.FECHA_PAGO_STRING = row.FECHA_PAGO.ToString("dd/MM/yyyy");
                }
                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}