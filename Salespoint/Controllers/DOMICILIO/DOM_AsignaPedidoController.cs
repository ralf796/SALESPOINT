using HELPERS;
using RESTAURANTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salespoint.Controllers.DOMICILIO
{
    public class DOM_AsignaPedidoController : Controller
    {
        // GET: DOM_AsignaPedido
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpireFilter]
        public PartialViewResult Get_PedidosPendientesDeEntregar()
        {
            var item = new Pedido_BE();
            item.MTIPO = 15;
            item.CREADO_POR = Session["usuario"].ToString();

            List<Pedido_BE> lista_encabezado;
            List<Pedido_BE> lista_detalle;
            lista_encabezado = Connect.Connect_Pedido(item);

            ViewBag.data_encabezado = lista_encabezado;
            return PartialView();
        }
    }
}