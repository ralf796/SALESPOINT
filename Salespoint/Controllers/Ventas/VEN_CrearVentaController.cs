using BE;
using GenesysOracleSV.Clases;
using Newtonsoft.Json;
using Salespoint.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salespoint.Controllers.VENTAS
{
    public class VEN_CrearVentaController : Controller
    {
        // GET: VEN_CrearVenta
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Get_Mesas()
        {
            var item = new Pedido_BE();
            item.MTIPO = 5;
            List<Pedido_BE> lista;
            lista = Connect.Connect_Pedido(item);
            ViewBag.data = lista;
            return PartialView();
        }

        public PartialViewResult Get_Categorias()
        {
            var item = new Pedido_BE();
            item.MTIPO = 6;
            List<Pedido_BE> lista;
            lista = Connect.Connect_Pedido(item);
            ViewBag.data = lista;
            return PartialView();
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

        public PartialViewResult Get_DetallesMesa(int id_mesa = 0)
        {
            var item = new Pedido_BE();
            item.MTIPO = 4;
            item.ID_MESA = id_mesa;
            item.CREADO_POR = Session["usuario"].ToString();

            List<Pedido_BE> lista;
            lista = Connect.Connect_Pedido(item);
            ViewBag.data = lista;
            return PartialView();
        }

        public JsonResult DeshabilitarMesa(int id_mesa = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.MTIPO = 8;
                item.ID_MESA = id_mesa;
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido deshabilitar la mesa.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Mesa deshabilitada correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }
        public JsonResult HabilitarMesa(int id_mesa = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.MTIPO = 9;
                item.ID_MESA = id_mesa;
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido habilitar la mesa.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Mesa habilitada correctamente";
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
        public JsonResult Create_DetalleMesa(int id_mesa = 0, int id_producto = 0, int cantidad = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.MTIPO = 1;
                item.ID_MESA = id_mesa;
                item.ID_PRODUCTO = id_producto;
                item.CANTIDAD = cantidad;
                item.CREADO_POR = Session["usuario"].ToString();
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido agregar el detalle.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Se agregó correctamente";
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
        public JsonResult Update_DetalleMesa_Observaciones(int id_mesa_menu = 0, string observaciones = "")
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.MTIPO = 2;
                item.ID_MESA_MENU = id_mesa_menu;
                item.OBSERVACIONES = observaciones;
                item.CREADO_POR = Session["usuario"].ToString();
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido actualizar la observación.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Observación actualizada correctamente";
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
        public JsonResult Delete_DetalleMesa(int id_mesa_menu = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.MTIPO = 3;
                item.ID_MESA_MENU = id_mesa_menu;
                item.CREADO_POR = Session["usuario"].ToString();
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido eliminar el menu.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Menu eliminado correctamente";
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
        public JsonResult Create_Pedido(int id_mesa = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                //List<Pedido_BE> lista = JsonConvert.DeserializeObject<List<Pedido_BE>>(detalles);

                string usuario = Session["usuario"].ToString();
                var item_Encabezado = new Pedido_BE();
                item_Encabezado.MTIPO = 12;
                item_Encabezado.ID_MESA = id_mesa;
                item_Encabezado.CREADO_POR = usuario;
                RESULT_SP = Connect.Connect_Pedido(item_Encabezado);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido crear el encabezado del pedido.";
                }
                else
                {
                    /*
                    int id_pedido_encabezado = RESULT_SP.FirstOrDefault().ID_PEDIDO_ENCABEZADO;

                    foreach(var row in lista)
                    {
                        List<Pedido_BE> RESULT_SP_DETALLE;
                        var item_Detalle = new Pedido_BE();
                        item_Detalle.MTIPO = 11;
                        item_Detalle.ID_PEDIDO= id_pedido_encabezado;
                        item_Detalle.ID_MENU_RESTAURANTE = row.ID_MENU_RESTAURANTE;
                        item_Detalle.CANTIDAD = row.CANTIDAD;
                        item_Detalle.OBSERVACIONES = row.OBSERVACIONES;
                        item_Detalle.CREADO_POR = usuario;
                        RESULT_SP_DETALLE = Connect.Connect_Pedido(item_Detalle);
                    }
                    */

                    item_Encabezado.MTIPO = 13;
                    RESULT_SP = Connect.Connect_Pedido(item_Encabezado);

                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Pedidio creado correctamente.";
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