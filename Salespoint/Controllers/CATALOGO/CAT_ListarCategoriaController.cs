using RESTAURANTE;
using GenesysOracleSV.Clases;
using HELPERS;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Salespoint.Controllers.CATALOGO
{
    public class CAT_ListarCategoriaController : Controller
    {
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Listar()
        {
            var item = new Catalogo_BE();
            item.MTIPO = 1;
            List<Catalogo_BE> lista;
            lista = Connect.Connect_Catalogo(item);
            ViewBag.data = lista;
            return PartialView();
        }

        [SessionExpireFilter]
        public JsonResult Guardar(string nombre = "", string descripcion = "")
        {
            var respuesta = new Respuesta();
            try
            {
                List<Catalogo_BE> RESULT_SP;
                Catalogo_BE item = new Catalogo_BE
                {
                    MTIPO = 3,
                    NOMBRE_CATEGORIA = nombre,
                    DESCRIPCION = descripcion,
                    CREADO_POR = Session["usuario"].ToString()
                };
                RESULT_SP = Connect.Connect_Catalogo(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido guardar la categoría.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Categoría creada correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }

        [SessionExpireFilter]
        public JsonResult Actualizar(int id_categoria = 0, string nombre = "", string descripcion = "")
        {
            var respuesta = new Respuesta();
            try
            {
                List<Catalogo_BE> RESULT_SP;
                Catalogo_BE item = new Catalogo_BE
                {
                    MTIPO = 4,
                    ID_CATEGORIA = id_categoria,
                    NOMBRE_CATEGORIA = nombre,
                    DESCRIPCION = descripcion,
                    CREADO_POR = Session["usuario"].ToString()
                };
                RESULT_SP = Connect.Connect_Catalogo(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido actualizar la categoría.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Categoría actualizada correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }

        [SessionExpireFilter]
        public JsonResult Eliminar(int id_categoria = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Catalogo_BE> RESULT_SP;
                Catalogo_BE item = new Catalogo_BE
                {
                    MTIPO = 5,
                    ID_CATEGORIA = id_categoria,
                    CREADO_POR = Session["usuario"].ToString()
                };
                RESULT_SP = Connect.Connect_Catalogo(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido guardar la categoría.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Categoría inactivada correctamente";
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

