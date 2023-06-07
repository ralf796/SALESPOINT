using HELPERS;
using Newtonsoft.Json;
using RESTAURANTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Salespoint.Controllers.VENTAS
{
    public class PED_PedidoCajaController : Controller
    {
        // GET: PED_PedidoCaja
        public ActionResult Index()
        {
            return View();
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

        [SessionExpireFilter]
        public JsonResult Create_Pedido(int tipo_pedido = 0, string detalles = "")
        {
            var respuesta = new Respuesta();
            try
            {
                string usuario = "ralopez"; // Session["usuario"].ToString();

                List<Pedido_BE> lista = JsonConvert.DeserializeObject<List<Pedido_BE>>(detalles);

                foreach (var row in lista)
                {
                    row.CREADO_POR = usuario;
                }

                string json = JsonConvert.SerializeObject(lista);

                List<Pedido_BE> RESULT_SP;
                var item_Encabezado = new Pedido_BE();
                item_Encabezado.CREADO_POR = usuario;
                item_Encabezado.ID_TIPO_PEDIDO = tipo_pedido;
                item_Encabezado.DETALLES_JSON = json;
                item_Encabezado.MTIPO = 19;
                RESULT_SP = Connect.Connect_Pedido(item_Encabezado);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Resultado = false;
                    respuesta.Codigo = 0;
                    respuesta.Descripcion = "No se ha podido crear el encabezado del pedido.";
                }
                else
                {
                    respuesta.Codigo = RESULT_SP.FirstOrDefault().ID_PEDIDO_ENCABEZADO;
                    respuesta.Descripcion = "Pedido creado correctamente.";
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