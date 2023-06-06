using HELPERS;
using RESTAURANTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salespoint.Controllers.VENTAS
{
    public class PED_PedidoCajaController : Controller
    {
        // GET: PED_PedidoCaja
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Get_Productos(int id_categoria = 0)
        {
            var item = new Pedido_BE();
            item.MTIPO = 7;
            item.ID_CATEGORIA = id_categoria;
            List<Pedido_BE> lista;
            lista = Connect.Connect_Pedido(item);
            ViewBag.data = lista;
            return PartialView();
        }
    }
}