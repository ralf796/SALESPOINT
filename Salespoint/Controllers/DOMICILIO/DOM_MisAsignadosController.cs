using BE;
using HELPERS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RESTAURANTE
{
    public class DOM_MisAsignadosController : Controller
    {
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpireFilter]
        public PartialViewResult Get_MisPedidos()
        {
            var item = new Pedido_BE();
            item.MTIPO = 22;
            item.CREADO_POR = Session["usuario"].ToString();

            List<Pedido_BE> lista;
            lista = Connect.Connect_Pedido(item);

            ViewBag.lista = lista;
            return PartialView();
        }

        [SessionExpireFilter]
        public JsonResult Entregar_Pedido(int id_pedido = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                string usuario = Session["usuario"].ToString();

                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.CREADO_POR = usuario;
                item.ID_PEDIDO_ENCABEZADO = id_pedido;
                item.MTIPO = 23;
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Resultado = false;
                    respuesta.Codigo = 0;
                    respuesta.Descripcion = "No se ha podido asignar pedido.";
                }
                else
                {
                    respuesta.Codigo = RESULT_SP.FirstOrDefault().ID_PEDIDO_ENCABEZADO;
                    respuesta.Descripcion = $"El pedido {id_pedido} te fué asignado correctamente.";
                    respuesta.Resultado = true;
                }

            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
                respuesta.Resultado = false;
            }
            return Json(respuesta);
        }
    }
}