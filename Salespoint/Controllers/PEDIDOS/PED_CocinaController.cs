using BE;
using HELPERS;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RESTAURANTE
{
    public class PED_CocinaController : Controller
    {
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpireFilter]
        public PartialViewResult Get_PedidosPendientes()
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

        [SessionExpireFilter]
        public PartialViewResult Get_PedidosPorMenu(int id_producto = 0, string titulo = "")
        {
            var item = new Pedido_BE();
            item.MTIPO = 16;
            item.ID_PRODUCTO = id_producto;
            item.CREADO_POR = Session["usuario"].ToString();

            List<Pedido_BE> lista_detalle;
            lista_detalle = Connect.Connect_Pedido(item);

            ViewBag.titulo = titulo;
            ViewBag.data_detalle = lista_detalle;
            return PartialView();
        }

        [SessionExpireFilter]
        public JsonResult DespacharLote(int id_producto = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item_Encabezado = new Pedido_BE();
                item_Encabezado.MTIPO = 17;
                item_Encabezado.ID_PRODUCTO=id_producto;
                RESULT_SP = Connect.Connect_Pedido(item_Encabezado);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido entregar el pedido Catch.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Menu entregado correctamente.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }
    }
}