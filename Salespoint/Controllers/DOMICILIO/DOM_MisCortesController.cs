using HELPERS;
using RESTAURANTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salespoint.Controllers.DOMICILIO
{
    public class DOM_MisCortesController : Controller
    {
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [SessionExpireFilter]
        public PartialViewResult Listar()
        {
            string usuario = Session["usuario"].ToString();
            var item = new Caja_BE();
            item.MTIPO = 2;
            item.CREADO_POR = usuario;
            List<Caja_BE> lista = new List<Caja_BE>();
            lista = Connect.Connect_Caja(item);
            ViewBag.data = lista;
            return PartialView();
        }

        [SessionExpireFilter]
        public JsonResult RealizarCorte()
        {
            var respuesta = new Respuesta();
            try
            {
                List<Caja_BE> RESULT_SP;
                string usuario = Session["usuario"].ToString();
                var item = new Caja_BE();
                item.MTIPO = 4;
                item.CREADO_POR = usuario;
                RESULT_SP = Connect.Connect_Caja(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Resultado = false;
                    respuesta.Descripcion = "No se ha podido realizar el corte.";
                }
                else
                {
                    respuesta.Resultado = true;
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Corte de Caja realizado correctamente.";
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