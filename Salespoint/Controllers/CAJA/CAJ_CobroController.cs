using HELPERS;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RESTAURANTE
{
    public class CAJ_CobroController : Controller
    {
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Listar()
        {
            var item = new Caja_BE();
            item.MTIPO = 1;
            List<Caja_BE> lista = new List<Caja_BE>();
            lista = Connect.Connect_Caja(item);
            ViewBag.data = lista;
            return PartialView();
        }

        [SessionExpireFilter]
        public JsonResult RealizarCobro(int id_pedido = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Caja_BE> RESULT_SP;
                string usuario = Session["usuario"].ToString();
                var item = new Caja_BE();
                item.MTIPO = 3;
                item.ID_PEDIDO = id_pedido;
                item.CREADO_POR = usuario;
                RESULT_SP = Connect.Connect_Caja(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Resultado = false;
                    respuesta.Descripcion = "No se ha podido realizar el cobro.";
                }
                else
                {
                    respuesta.Resultado = true;
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Cobro realizado correctamente.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Resultado = false;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }
    }
}